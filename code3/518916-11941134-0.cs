    public abstract class BaseClass<T>
    {
        protected abstract List<T> DoSomeMethod();
        public List<T> SomeMethod()
        {
            return DoSomeMethod();
        }
    }
    public class ChildClass : BaseClass<ChildClass>
    {
        protected override List<ChildClass> DoSomeMethod(){ ... }
    }
