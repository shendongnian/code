    using System;
    using System.Collections.Generic;
    namespace QuickTest
    {
        public interface IRepository
        {
            void test();
        }
        public class GenericRepository<t> : IRepository
        {
            public void test() { Console.WriteLine(this.GetType().ToString()); }
        }
        class Program
        {
            public static void Main(string[] argv)
            {
                var o = new GenericRepository<string>();
                o.test(); // prints QuickTest.GenericRepository`1[System.String]
                Type genericType = typeof(GenericRepository<>).MakeGenericType(new[]{typeof(string)});
                IRepository repo = Activator.CreateInstance(genericType) as IRepository;
                // use it in a nice early language bound way
                repo.test(); // prints QuickTest.GenericRepository`1[System.String]
            }
        }
    }
