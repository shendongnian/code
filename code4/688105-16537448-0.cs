    public interface iClass {
        bool SomeMethod(iObject obj);
    }
    
    public interface iObject {
    }
    
    public class ObjectImplementation : iObject {
    }
    
    public class ClassImplementation : iClass {
        public bool SomeMethod(iObject obj)
        {
            return false;
        }
    }
