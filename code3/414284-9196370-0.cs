        class Program
        {
            static void Main(string[] args)
            {
                var testType = new TestType {GenList = new List<string> {"test", "type"}};
    
                foreach(var prop in typeof (TestType).GetProperties())
                {
                    if (prop.PropertyType.IsGenericType)
                    {
                        var genericTypeArgs = prop.PropertyType.GetGenericArguments();
                        if (genericTypeArgs.Length!=1 || !(genericTypeArgs[0] == typeof(string)))
                             continue;
    
                        var genEnum = typeof (IEnumerable<>).MakeGenericType(genericTypeArgs);
    
                        if (genEnum.IsAssignableFrom(prop.PropertyType))
                        {
                            var propVal = (IList)prop.GetValue(testType, BindingFlags.GetProperty, null, null, null);
    
                            foreach (var item in propVal)
                                Console.WriteLine(item);
                        }
                    }
                }
    
                Console.ReadLine();
            }
        }
    
        public class TestType
        {
            public IList<string> GenList { get; set; }
        }
