    public abstract class AbstractClass {
        protected static void Method<T>() {
    	    Method(typeof(T));
        }
        protected static void Method(Type t) {
    	    // put your logic here
        }
        protected void Method() {
            Method(GetType());
        }
    }
