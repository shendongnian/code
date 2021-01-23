    public class MyClass {
        public IBase GetObject<T>() where T:IBase, new() // EDIT: Added new constraint 
        {
            // should return the object based on type.
            return new T();
        }
    
    }
