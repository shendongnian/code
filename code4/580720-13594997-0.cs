    namespace ConsoleApplication8
    {
        public class MyEntity
        {
            public int Id { get; set; }
            public int Number { get; set; }
        }
        public class MyContext : DbContext
        {
            public DbSet<MyEntity> Entities { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                using (var ctx = new MyContext())
                {
                    if (!ctx.Entities.Any())
                    {
                        ctx.Entities.Add(new MyEntity() {Number = 123});
                        ctx.Entities.Add(new MyEntity() {Number = 1893});
                        ctx.Entities.Add(new MyEntity() {Number = 46});
                        ctx.SaveChanges();
                    }
                    foreach(var entity in ctx.Entities.Where(e => SqlFunctions.StringConvert((double?) e.Number).Contains("6")))
                    {
                        Console.WriteLine("{0} {1}", entity.Id, entity.Number);
                    }
                    foreach (var entity in ctx.Entities.Where(BuildLambda<MyEntity>("Number", "6")))
                    {
                        Console.WriteLine("{0} {1}", entity.Id, entity.Number);
                    }
                }
            }
            private static Expression<Func<T, bool>> BuildLambda<T>(string propertyName, string value)
            {
                var parameterExpression = Expression.Parameter(typeof(T), "e");
                var stringConvertMethodInfo = 
                    typeof(SqlFunctions).GetMethod("StringConvert", new Type[] {typeof (double?)});
                var stringContainsMethodInfo =
                    typeof (String).GetMethod("Contains");
                return 
                    Expression.Lambda<Func<T, bool>>(
                    Expression.Call(
                        Expression.Call(
                            stringConvertMethodInfo,
                            Expression.Convert(
                                Expression.Property(parameterExpression, "Number"),
                                typeof (double?))),
                        stringContainsMethodInfo,
                        Expression.Constant(value)),
                    parameterExpression);
            }
        }
    }
