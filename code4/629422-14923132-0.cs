    public interface IFirst
    {
        string FirstMethod();
    }
    public interface ISecond
    {
        string SecondMethod();
    }
    internal interface IBase
    {
        string BaseMethod();
    }
    public class First: IFirst, IBase
    {
        public static IFirst Create()  // Don't really need a factory method;
        {                              // this is just as an example.
            return new First();
        }
        private First()  // Don't really need to make this private,
        {                // I'm just doing this as an example.
        }
        public string FirstMethod()
        {
            return "FirstMethod";
        }
        public string BaseMethod()
        {
            return "BaseMethod";
        }
    }
    public class Second: ISecond, IBase
    {
        public static ISecond Create()  // Don't really need a factory method;
        {                               // this is just as an example.
            return new Second();
        }
        private Second()  // Don't really need to make this private,
        {                 // I'm just doing this as an example.
        }
        public string SecondMethod()
        {
            return "SecondMethod";
        }
        public string BaseMethod()
        {
            return "BaseMethod";
        }
    }
