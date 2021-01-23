    using System.Linq;
    using System.Linq.Expressions;
    using System;
     
    namespace SomeNameSpace
    {
        public static class SomeExtensionClass
        {
            public static IQueryable<T> OrderByField<T>(this IQueryable<T> q, string SortField, bool Ascending)
            {
                var param = Expression.Parameter(typeof(T), "p");
                var prop = Expression.Property(param, SortField);
                var exp = Expression.Lambda(prop, param);
                string method = Ascending ? "OrderBy" : "OrderByDescending";
                Type[] types = new Type[] { q.ElementType, exp.Body.Type };
                var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
                return q.Provider.CreateQuery<T>(mce);
            }
        }
