    public static ExtensionMethods
    {
        public static T Validate<T>(this T myObj, Func<T, bool> expression) 
             where T : class
        { 
        }
    }
       
