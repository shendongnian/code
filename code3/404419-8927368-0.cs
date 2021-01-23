    abstract class Base
    {
        public abstract string Metadata();
    }
    class Derived1 : Base
    {
        public override string Metadata()
        {
            return "Metadata for Derived1";
        }
    }
    class Derived2 : Base  // won't compile, since Metadata has not been provided
    {
    }
