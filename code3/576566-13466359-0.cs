    public class MyClass {
        public IBase GetObject<T>() where T:IBase
        {
            // should return the object based on type.
            return new T();
        }
    
    }
