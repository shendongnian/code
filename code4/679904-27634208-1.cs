    public class DepartmentDb : DbContext, IDepartmentDataSource
    {
        public DbSet<Department> Departments { get; set; }
        IQueryable<Department> IDepartmentDataSource.Departments
        {
            get { return Departments; }
        }
    }
