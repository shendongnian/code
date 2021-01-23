    public bool IsUnique(params Func<Employee, bool>[] predicates)
    {
        var rowCount = _session.QueryOver<Employee>()
                 .CombinedWhere(predicates).ToRowCountQuery().RowCount();
        return rowCount == 0;
    }
    
    var isUnique = _employeeRepository.IsUnique(
                 x => x.FirstName == commandMessage.FirstName,
                 x => x.LastName == commandMessage.LastName);
