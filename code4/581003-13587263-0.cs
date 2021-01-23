    using System.Linq;
    using System.Collections.Generic;
    namespace ConsoleApplication1
    {
        public class Class1
        {
            public int id { get; set; }
            public List<Class2> attr { get; set; }
        }
        public class Class2
        {
            public int id { get; set; }
        }
        class MyEntity
        {
            public int ID { get; set; }
            public MyEntity(int id)
            {
                ID = id;
            }
        }
        class MyContext : List<MyEntity>
        {
        }
        class Program
        {
            static void Main(string[] args)
            {
                var context = new MyContext();
                context.Add(new MyEntity(1));
                context.Add(new MyEntity(2));
                context.Add(new MyEntity(3));
                context.Add(new MyEntity(4));
                context.Add(new MyEntity(5));
                var q = (from m in context
                         select new Class1
                         {
                             id = m.ID,
                             attr = (from t in context
                                     where m.ID == t.ID
                                     select new Class2
                                     {
                                         id = t.ID
                                     }).Take(5).ToList()
                         }).Take(1).ToList();
            }
        }
    }
