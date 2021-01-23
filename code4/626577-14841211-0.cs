    public static class DbContextExtensions 
    {
        public static IQueryable<Employee> WhereX(this IQueryable<Employee> queryable, int id)
        {
            return queryable.Where(e => e.CostCenterID == 123);
        }
    }
