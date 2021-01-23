    public interface ISomeInterface
    {
        void SomeMethod();
    }
    public class SomeClass : ISomeInterface
    {
        void SomeInterface.SomeMethod()
        {
            // ...
        }
    }
