    public static class MyStaticClass
    {
        public static void MyStaticMethod()
        {...}
    }
    public interface IStaticWrapper
    {
        void MyMethod();
    }
    public class MyClass : IStaticWrapper
    {
        public void MyMethod()
        {
            MyStaticClass.MyStaticMethod();
        }
    }
