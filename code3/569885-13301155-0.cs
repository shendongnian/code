    public IQueryable<Employee> FilterEmployees(IQueryable<Employee> query, DateTime startDate, DateTime endDate, string employeeName, EmployeeStatus employeeStatus)
    {
    	var predicate = PredicateBuilder.True<Employee>();
    
    	//All names starting with 'A'
    	predicate = predicate.And(x => x.Name.StartsWith('A'));
    	
    	//Add a condition only if the employee is PartTime
    	if (employeeStatus == EmployeeStatus.PartTime)
    	{
    		//Add condition for when they start
    		predicate = predicate.And(x => x.StartDate >= startDate);
    	}
    	else //Add condition for when non-part-time employees are due to leave
    	{
    		predicate = predicate.And(x => x.EndDate <= endDate);
    		//or their name ends in 'z'
    		predicate = predicate.Or(x => x.Name.EndsWith('z'));
    	}
    
    	IQueryable<Employee> employees = query.FindBy(predicate); //you should probably use a repository here to return your query
    	
    	return employees
    	
    }
