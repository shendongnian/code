    public class Program
    {
        private static IList<Company> _companies;
        static void Main(string[] args)
        {
            var sort = "Employees.Count";
            _companies = new List<Company>();
            _companies.Add(new Company
                               {
                                   Name = "c2",
                                   Address = new Address {PostalCode = "456"},
                                   Employees = new List<Employee> {new Employee(), new Employee()}
                               });
            _companies.Add(new Company
                               {
                                   Name = "c1",
                                   Address = new Address {PostalCode = "123"},
                                   Employees = new List<Employee> { new Employee(), new Employee(), new Employee() }
                               });
            //display companies
            _companies.AsQueryable().OrderBy(sort).ToList().ForEach(c => Console.WriteLine(c.Name));
            Console.ReadLine();
        }
    }
    public class Company
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public IList<Employee> Employees { get; set; }
    }
    public class Employee{}
    public class Address
    {
        public string PostalCode { get; set; }
    }
    public static class OrderByString
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "OrderBy");
        }
        public static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
        {
            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                PropertyInfo pi = type.GetPublicProperties().FirstOrDefault(c => c.Name == prop);
                if (pi != null)
                {
                    expr = Expression.Property(expr, pi);
                    type = pi.PropertyType;
                }
                else { throw new ArgumentNullException(); }
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);
            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<T>)result;
        }
        public static PropertyInfo[] GetPublicProperties(this Type type)
        {
            if (type.IsInterface)
            {
                var propertyInfos = new List<PropertyInfo>();
                var considered = new List<Type>();
                var queue = new Queue<Type>();
                considered.Add(type);
                queue.Enqueue(type);
                while (queue.Count > 0)
                {
                    var subType = queue.Dequeue();
                    foreach (var subInterface in subType.GetInterfaces())
                    {
                        if (considered.Contains(subInterface)) continue;
                        considered.Add(subInterface);
                        queue.Enqueue(subInterface);
                    }
                    var typeProperties = subType.GetProperties(
                        BindingFlags.FlattenHierarchy
                        | BindingFlags.Public
                        | BindingFlags.Instance);
                    var newPropertyInfos = typeProperties
                        .Where(x => !propertyInfos.Contains(x));
                    propertyInfos.InsertRange(0, newPropertyInfos);
                }
                return propertyInfos.ToArray();
            }
            return type.GetProperties(BindingFlags.FlattenHierarchy
                | BindingFlags.Public | BindingFlags.Instance);
        }
    }
