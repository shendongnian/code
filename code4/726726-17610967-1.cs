    IEnumerable<EmployeeViewModel> employees = 
        from m in t.Employees
        join e1 in t.Employees on m.ManagerID equals e1.EmployeeID
        select new EmployeeViewModel
        { 
            EmployeeID = m.EmployeeID , 
            Name = m.Name, 
            ManagerName = e1.Name,
            Designation = m.Designation,
            Phone = m.Phone,
            Address = m.Address 
        };
        return View(employees.ToList());
