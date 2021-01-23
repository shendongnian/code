    static class ExtensionMethods { }
    // notice non-static
    class AnotherNonStaticExtensionMethod { }
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine(Test(new AnotherNonStaticExtensionMethod()).ToString());
            Debug.WriteLine(Test("Test").ToString());
            Debug.WriteLine(Test(4).ToString());
        }
        public static bool Test(object obj)
        {
            if (obj is ExtensionMethods)
            {
                return true;
            }
            else if (obj is AnotherNonStaticExtensionMethod)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
