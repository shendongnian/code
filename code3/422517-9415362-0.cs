    public interface IMyInterface
    {
        void MyMethod();
    }
    public class MyClass : IMyInterface
    {
        static void MyMethod()
        {
        }
        void IMyInterface.MyMethod()
        {
            MyClass.MyMethod();
        }
    }
