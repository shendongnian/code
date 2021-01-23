    public partial class MyEntity
    {
        public int ID { get; set; }
        public int Type { get; set; }
        public string X { get; set; }
    }
    public class MyContext : DbContext
    {
        public DbSet<MyEntity> Entities { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyContext>());
            using (var ctx = new MyContext())
            {
                if (!ctx.Entities.Any())
                {
                    ctx.Entities.Add(new MyEntity() { ID = 1, Type = 2, X = "ABC" });
                    ctx.SaveChanges();
                }
                Console.WriteLine(DoesColValueExist(ctx.Entities, e => e.X, "aBc"));
                Console.WriteLine(DoesColValueExist(ctx.Entities, e => e.X, "aBcD"));
                Console.WriteLine(DoesColValueExist(ctx.Entities, e => e.Type, 2));
                Console.WriteLine(DoesColValueExist(ctx.Entities, e => e.Type, 5));
            }
        }
        private static bool DoesColValueExist<TEntity, TProperty>(IQueryable<TEntity> dataToSearchIn, Expression<Func<TEntity, TProperty>> property, TProperty colValue)
        {
            var memberExpression = property.Body as MemberExpression;
            if (memberExpression == null || !(memberExpression.Member is PropertyInfo))
            {
                throw new ArgumentException("Property expected", "property");
            }
            
            Expression left = property.Body;
            Expression right = Expression.Constant(colValue, typeof(TProperty));
            if (typeof(TProperty) == typeof(string))
            {
                MethodInfo toLower = typeof(string).GetMethod("ToLower", new Type[0]);
                left = Expression.Call(left, toLower);
                right = Expression.Call(right, toLower);
            }
            Expression searchExpression = Expression.Equal(left, right);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(Expression.Equal(left, right), new ParameterExpression[] { property.Parameters.Single() });
            return dataToSearchIn.Where(lambda).Any();                
        }
    }
