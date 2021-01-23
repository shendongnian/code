    class Program
    {
        /// <summary>
        /// a dictionary for holding the desired return values
        /// </summary>
        static Dictionary<string, object> _testReturnValues = new Dictionary<string, object>();
        static void Main(string[] args)
        {
            // adding the test return for method X
            _testReturnValues.Add("X", true);
            
            var result = ExecuteMethod(typeof(MyClass), "X");
            Console.WriteLine(result);
        }
        static object ExecuteMethod(Type type, string methodName)
        {
            try
            {
                return type.InvokeMember(methodName, BindingFlags.InvokeMethod, null, null, null);
            }
            catch (MissingMethodException e)
            {
                // getting the test value if the method is missing
                return _testReturnValues[methodName];
            }
        }
    }
    class MyClass
    {
        //public static string X() 
        //{
        //    return "Sample return";
        //}
    }
