    public class BaseClass // or abstract
    {
        public void foo(int x)
        {
            //your implementation
        }
    }
    public class ChildClass : BaseClass
    {
        public void foo(int x) : base(x)
        {
            //your implementation
        }
    }
