    // Extension Method example
    
    public static class ConstantExtensions
    {
           public static void WriteToConsole(this string constant)
           {
              Console.WriteLine(constant);
           }
    
    }
    public static class Constants
    {
        public static readonly string SomeMessage = "Hello world!";
        public static readonly string OtherMessage = "Goodbye world!";
        ...
    }
    Constants.SomeMessage.WriteToConsole();
