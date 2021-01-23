    abstract class BaseClass
    {
        public void Method() {
            // Common tasks
        }
    }
    class RealClass : BaseClass 
    {
        public void Method() {
             base.Method();
             // custom tasks for this class
        }
    }
