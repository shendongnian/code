    using System;
    
    public class Address {}
    
    public interface IRepository<T> : IDisposable
    {
        void Add(T model);
        void Update(T model);
    }
    
    public interface IAddressRepository : IRepository<Address>
    {
    }
    
    class Program
    {
        public static void Main()
        {
            using (var repo = GetRepository())
            {
            }
        }
        
        private static IAddressRepository GetRepository()
        {
            // TODO: Implement :)
            return null;
        }
    }
