    using System;
    using System.Collections.Generic;
    namespace QuickTest
    {
        public interface IRepository
        {
            void test();
        }
        public class GenericRepositoryFactory
        {
            static public IRepository CreateInstance(params Type[] p)
            {
                Type genericType = typeof(GenericRepository<>).MakeGenericType(p);
                return Activator.CreateInstance(genericType) as IRepository;
            }
        }
        public class GenericRepository<t> : IRepository
        {
            public void test() { Console.WriteLine(this.GetType().ToString()); }
        }
        class Program
        {
            public static void Main(string[] argv)
            {
                var repo = GenericRepositoryFactory.CreateInstance(new[] { typeof(string) });
                repo.test();
            }
        }
    }
