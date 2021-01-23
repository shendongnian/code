     public class Person
        {
            public string FirstName { get; set; }
    
            public string LastName { get; set; }
    
            public int Age { get; set; }
        }
    
        public static class MyHelper
        {
            public static void UppercaseClassFields<T, T2>(T theInstance)
                where T : IEnumerable<T2>
            {
                if (theInstance == null)
                {
                    throw new ArgumentNullException();
                }
    
                foreach (var theItem in theInstance)
                {
                    foreach (var property in theItem.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                    {
                        var theValue = property.GetValue(theItem, null);
                        if (theValue is string)
                        {
                            property.SetValue(theItem, ((string)theValue).ToUpper(), null);
                        }
                    }
                }
            }
        }
    
        public class Program
        {
            private static void Main(string[] args)
            {
                List<Person> myList = new List<Person>{
                    new Person { FirstName = "Aaa", LastName = "BBB", Age = 2 },
                    new Person{ FirstName = "Deé", LastName = "ève", Age = 3 }
                };
    
                MyHelper.UppercaseClassFields<List<Person>, Person>(myList);
    
                Console.ReadLine();
            }
        }
