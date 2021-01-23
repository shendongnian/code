    private IRowMapper<T> GetRowMapper<T>() where T : Person, new()
    {
        var rowMapper = MapBuilder<T>.MapNoProperties()
                                     .Map(c => c.Id).ToColumn("ID");
    
        if (typeof (T) == typeof (Employee))
        {
            rowMapper = ((IMapBuilderContextMap<Employee>)rowMapper)
                .Map(c => c.EmployerId).ToColumn("EmployerID");
        }
        else if (typeof (T) == typeof (Employer))
        {
            rowMapper = ((IMapBuilderContextMap<Employer>)rowMapper)
                .Map(c => c.EmployeeId).ToColumn("EmployeeId");
        }
    
        return rowMapper.Build();
    }
