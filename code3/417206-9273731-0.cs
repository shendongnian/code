        public interface IGetMethod<T>
        {
           IEnumerable<T> get(String name);
        }
        class GetByName<T> : IGetMethod<T>
        {
           IEnumerable<T> get(String name)
           {
               // ...
           }
        }
        
        public interface IRepository<T>
        {
        
            IEnumerable<T> GetAllByMethod(IGetMethod<T> method, string name);
        }
