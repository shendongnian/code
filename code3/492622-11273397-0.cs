    abstract public class A
    {
        protected A(int a, int b)
        {
        }
    }
    internal class B : A
    {
        public B(int a, int b, string Err)
            : base(a, b)
        {
        }
    }
