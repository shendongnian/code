    public class Base { }
    public class Derived : Base { }
    public class Component
    {
        public virtual Base GetComponent()
        {
            return new Base();
        }
    }
    public class DerviedComponent : Component
    {
        public override Dervied GetComponent()
        {
            return new Derived();
        }
    }
