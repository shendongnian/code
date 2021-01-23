    ...
    return _context.Employee
        .Where(EmployeeExpressions.IsTempAndNotDeleted)
        .ToList();
    ...
    return _context.Company
        .Where(c => c.Employees.Any(EmployeeExpressions.IsTempAndNotDeleted))
        .ToList();
