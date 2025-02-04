﻿using System.Collections.ObjectModel;
using CheckInSystem.Models;
using CheckInSystem.Platform;
using CheckInSystem.Views.Windows;

namespace CheckInSystem.ViewModels.UserControls;

public class AdminEmployeeViewModel : ViewModelBase
{
    public ObservableCollection<Employee> SelectedEmployeeGroup { get; set; }
    public static ObservableCollection<Employee> SelectedEmployees { get; set; }
    public ObservableCollection<Employee> AllEmployees { get; set; }
    public AdminEmployeeViewModel(IPlatform platform, ObservableCollection<Employee> employees) : base(platform)
    {
        SelectedEmployeeGroup = employees;
        SelectedEmployees = new();
        Employees = new();
    }

    public void EditEmployee(Employee employee)
    {
        EditEmployeeWindow.Open(employee);
    }

    public void DeleteEmployee(Employee employee)
    {
        employee.DeleteFromDb();
        foreach (var group in Groups)
        {
            group.Members.Remove(employee);
        }
        Employees.Remove(employee);
    }
}