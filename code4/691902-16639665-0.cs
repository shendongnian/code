    public class Base
    {
        public virtual void Function()
        {
        }
    }
    public class Derived: Base
    {
        public static  Derived Create()
        {
            return new Derived();
        }
        private Derived()
        {
            // Code analysis warning: CS2214 "Do not call overridable methods in constructors".
            Function(); 
        }
    }
