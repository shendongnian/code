    public EmployeeContext()
                : base()
            {
                Database.SetInitializer<EmployeeContext>(new DropCreateDatabaseIfModelChanges<EmployeeContext>());
            }
