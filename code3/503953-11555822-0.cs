    public interface IclassBndC {}
    
    public class B : IclassBandC {}
    
    public class C : IclassBandC {}
    
    public class A : IExtender
    {
        public T GetValue<T>(string tag) where T : IclassBandC 
        {
            if (tag == null)
                return new B();
            if (tag == "foo")
                return new C();
            return default(T);
        }
    }
