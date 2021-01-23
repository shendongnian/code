    private Department ExecuteCommand<T>(T databaseCommand) where T : class
    {
                Department department = new Department ();
    
                var command = databaseCommand;
    
                using (var databaseReader = command.ExecuteReader())
                {
                    if ((databaseReader as IDataReader).HasRows)
                    {
    
                        while ((databaseReader as IDataReader).Read())
                        {
                              department.Employees.Add(this.CreateDepartmentInstance(databaseReader));
                        }
                    }
                }
    
                command.Connection.Dispose();
    
                return department;
            }
