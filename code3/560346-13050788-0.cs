        internal class Program {
    
            private static void Main() {
    
                string customerString = @"Customer";
                string employeeString = @"Employee";
    
                object customerRepository = GetGenericRepository(customerString);
                object employeeRepository = GetGenericRepository(employeeString);
    
                System.Console.WriteLine();
            }
    
            public static object GetGenericRepository(string typeName) {
    
                // get the type from the string
                System.Type type = GetTypeFromName(typeName);
    
                System.Type repositoryOpenType = typeof(GenericRepository<>);
                System.Type repositoryClosedType = repositoryOpenType.MakeGenericType(type);
    
                return System.Activator.CreateInstance(repositoryClosedType);
            }
    
            // there are better methods for getting the type by name
            private static System.Type GetTypeFromName(string typeName) {
    
                System.Type type = System.Type.GetType(typeName, false);
    
                if (type == null) {
    
                    var types = from assemblyType in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                                where assemblyType.Name == typeName
                                select assemblyType;
    
                    type = types.FirstOrDefault();
                }
    
                return type;
            }
        }
    
        public class Customer {
        }
    
        public class Employee {
        }
    
        public class GenericRepository<T> where T : class {
        }
    }
