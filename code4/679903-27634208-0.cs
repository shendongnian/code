              public DbSet<Department> Departments { get; set; }
              IQueryable<Department> IDepartmentDataSource.Departments
        {
            get { return Departments; }
        }
