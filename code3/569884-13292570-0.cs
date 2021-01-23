    public IQueryable<Employee> FilterEmployees(IQueryable<Employee> query, DateTime? startDate, DateTime? endDate, string employeeName, EmployeeStatus employeeStatus)
    {
        if (startDate != null)
            query = query.Where(x => x.StartDate >= startDate);
        
        // etc...
        return query;
    }
