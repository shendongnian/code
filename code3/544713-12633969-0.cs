    using System;
    using System.Linq.Expressions;   
    
    static class Program
    {
        static void Main()
        {
            var obj = new Foo { Id = 2 };
            WriteId(obj, 6);
            Console.WriteLine(obj.Id); // 6
        }
    
        private static class SneakyCache<T>
        {
            public static readonly Action<T, int> SetId;
            static SneakyCache()
            {
                var obj = Expression.Parameter(typeof(T), "obj");
                var id = Expression.Parameter(typeof(int), "id");
                SetId = Expression.Lambda<Action<T, int>>(
                      Expression.Assign(Expression.Property(obj, "Id"), id),
                      obj, id).Compile();
            }
        }
        public static void WriteId<T>(T obj, int id) where T : class
        {
            SneakyCache<T>.SetId(obj, id);
        }
    }
    class Foo
    {
        public int Id { get; set; }
    }
