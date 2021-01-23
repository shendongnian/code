    public abstract class AbstractClass
    {
        protected static void Method<T>() where T : AbstractClass
        {
            Type t = typeof (T);
            
        }
    }
    
    public class CurrentClass : AbstractClass
    {
    
        public void DoStuff()
        {
            Method<CurrentClass>(); // Here I'm calling it
        }
    
    }
