    using System;
    using System.Linq;
    using System.Reflection;
    using System.Data.Objects.SqlClient;
    using System.Linq.Expressions;
    public class FilterDescription
    {
        public enum FilterPatternType
        {
            Contains = 1,
            Range = 2, // [^0-9]
        }
        public string Field { get; set; }
        public string FilterPhrase { get; set; }
        public FilterPatternType PatternType { get; set; }
    }
    public static class FilterBuilder
    {
        private static readonly MethodInfo PatIndexMethod = typeof(SqlFunctions).GetMethod("PatIndex");
        private static readonly ConstantExpression ValueZero = Expression.Constant(0, typeof(int?));
        public static string ParsePropertyValue(FilterDescription filter)
        {
            switch (filter.PatternType)
            {
                case FilterDescription.FilterPatternType.Contains:
                    return string.Format("%{0}%", filter.FilterPhrase);
                case FilterDescription.FilterPatternType.Range:
                    return string.Format("[^{0}]", filter.FilterPhrase);
                default:
                    throw new InvalidOperationException("Pattern type not supported");
            }
        }
        
        public static Expression<Func<TEntity, bool>> BuildFilterExpression<TEntity>(string patternString, string targetProperty)
        {
            var patternStringArg = Expression.Constant(patternString);
            var entityType = Expression.Parameter(typeof(TEntity), "item");
            var targetPropertyArg = Expression.PropertyOrField(entityType, targetProperty);
            MethodCallExpression patIndexCall = Expression.Call(PatIndexMethod, patternStringArg, targetPropertyArg);
            var isGreaterThanZero = Expression.GreaterThan(patIndexCall, ValueZero);
            return Expression.Lambda<Func<TEntity, bool>>(isGreaterThanZero, entityType);
        }
        public static Expression<Func<TEntity, bool>> BuildFilterExpression<TEntity>(FilterDescription filter)
        {
            var pattern = ParsePropertyValue(filter);
            return BuildFilterExpression<TEntity>(pattern, filter.Field);
        }
        public static IQueryable<TEntity> Filter<TEntity>(this IQueryable<TEntity> toFilter, FilterDescription filter)
        {
            return toFilter.Where(BuildFilterExpression<TEntity>(filter));
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        private static IQueryable<Person> GetPersons()
        {
            return (IQueryable<Person>)null; // use your own data.
        }
        public static void Main(params string[] args)
        {
            var filter = new FilterDescription() 
            { 
                PatternType = FilterDescription.FilterPatternType.Contains,
                Field = "FirstName",
                FilterPhrase = "ed"
            };
            var filtered = GetPersons().Filter(filter);
        }
    }
