    // The following extension methods can be accessed by instances of any  
    // class that is or inherits MyClass. 
    public static class Extension
    {
        public static void MethodA(this MyClass myInterface, int i)
        {
            Console.WriteLine
                ("Extension.MethodA(this IMyInterface myInterface, int i)");
        }
    }
