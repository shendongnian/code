    public class BaseClass<T> where T : BaseClass<T> {
        public abstract T TestMethod(...);
    }
    
    public class ClassA : BaseClass<ClassA>
    {
        public override ClassA TestMethod(...)
        {
            // ...
        }   
    }
