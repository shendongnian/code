    internal static class Program
    {
        private static void Main(string[] args)
        {
            MethodInfo methodInfo = typeof (Program).GetMethod
                ("TestMethod", BindingFlags.Static | BindingFlags.Public);
            bool hasAttribute = HasCustomAttribute(methodInfo);
        }
    
        [CustomAttribute("Custom Attribute!")]
        public static void TestMethod()
        { 
        }
    
        public static bool HasCustomAttribute(MethodInfo methodInfo, bool inherit = false)
        {
            return methodInfo.GetCustomAttribute<CustomAttribute>(inherit) != null;
        }
    }
    
    internal class CustomAttribute : Attribute
    {
        public string Message { get; set; }
    
        public CustomAttribute(string message)
        {
            Message = message;
        }
    }
