    static class EmployeeExpressions
    {
        public static System.Linq.Expressions.Expression<Func<Employee, bool>>
            IsTempAndNotDeleted = e => e.IsTemp && !e.IsDeleted;
    }
