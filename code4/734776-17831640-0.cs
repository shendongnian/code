    namespace MyCompany.Extensions
    {
        public static class MyClassExtensions
        {
            public static string ExtensionMethod1(this MyClass myClass)
            {
                myClass.DoStuff();
                return "whatever I want my string to be";
            }
            public static string ExtensionMethod2(this MyClass myClass)
            {
                myClass.DoOtherStuff();
                return "the output of ExtensionMethod2";
            }
        }
        public class MyClass
        {
            public void DoStuff()
            {
                // do whatever
            }
            public void DoOtherStuff()
            {
                // do whatever else
            }
        }
    }
