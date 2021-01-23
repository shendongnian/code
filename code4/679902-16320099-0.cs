    public class DepartmentDb : DbContext, IDepartmentDataSource 
    {
        //Error: property cannot implement property.... 
        public DbSet<Department> Departments { get; set; } 
    }
    public class MyQueryable<T> : IQueryable<T> {}
    ....
    MyDepartmentDb.Departments = new MyQueryable<Department>(); // Error!
    // but it implements IDepartmentDataSource
    // which should let any IQueryable<Department> in, so what gives??
