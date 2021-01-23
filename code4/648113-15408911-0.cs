    private Department ExecuteCommand<T>(T databaseCommand) where T : IDbCommand
    {
        Department department = new Department();
    
        using (IDataReader databaseReader = databaseCommand.ExecuteReader())
        {
            if (databaseReader.HasRows)
            {
    
                while (databaseReader.Read())
                {
                    department.Employees.Add(
                                     this.CreateDepartmentInstance(databaseReader));
                }
            }
        }
    
        command.Connection.Dispose();
    
        return department;
    }
