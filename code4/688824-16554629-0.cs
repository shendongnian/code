    var toBeDeleted = employees.Select(e => e.EmployeeName)
                               .Where(name => customers.Any(c => c.CustomerName == name))
                               .ToList();
    customers.RemoveAll(c => toBeDeleted.Contains(c.CustomerName));
    employees.RemoveAll(e => toBeDeleted.Contains(e.EmployeeName));
