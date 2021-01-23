    public abstract class BaseClass<T>
    {
        public abstract List<T> SomeMethod();
    }
    public class ChildClass : BaseClass<ChildClass>
    {
        public override List<ChildClass> SomeMethod() { ... }
    }
