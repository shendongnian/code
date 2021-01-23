        public class Entity
        {
        }
    
        public class SpecificEntity : Entity
        {
        }
    
        public class Program
        {
            public static void Save<T>(T entity)
                where T : class
            {
                Console.WriteLine(entity.GetType().FullName);
            }
    
            public static void Save(SpecificEntity entity)
            {
                Console.WriteLine(entity.GetType().FullName);
            }
    
            private static void Main(string[] args)
            {
                Save(new Entity());          // ConsoleApplication13.Entity
                Save(new SpecificEntity());  // ConsoleApplication13.SpecificEntity
    
                Console.ReadKey();
            }
        }
