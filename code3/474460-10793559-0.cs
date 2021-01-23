    public class CBRegistrar<T>
    {
        private Action<T> callback;
        private Dictionary<Type, object> callbackMap;
        
        public CBRegistrar()
        {
            this.callbackMap = new Dictionary<Type, object>();
        }
        
        public void RegisterCallback(Action<T> func)
        {
            this.callback = func;
        }
    
        public void RegisterGenericCallback<U>(Action<U> func)
        {
            this.callbackMap[typeof(U)] = func;
        }
    
        public Action<U> GetCallback<U>()
        {
            return this.callbackMap[typeof(U)] as Action<U>;
        }
    }
    public interface ISomeClass
    {
        string GetName();
    }
    
    public class SomeClass : ISomeClass
    {
        public string GetName()
        {
            return this.GetType().Name;
        }
    }
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                var callbackRegistrar = new CBRegistrar<ISomeClass>();
    
                callbackRegistrar.RegisterCallback(SomeFunc);
                callbackRegistrar.RegisterGenericCallback<ISomeClass>(SomeFunc);
    
                var someone = new SomeClass();
    
                callbackRegistrar.GetCallback<ISomeClass>()(someone);
            }
    
            public static void SomeFunc(ISomeClass data)
            {
                // Do something
                Console.WriteLine(data.GetName());
            }
        }
    }
