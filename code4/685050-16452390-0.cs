    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class MyRegularExpressionAttribute : RegularExpressionAttribute
    {
        public MyRegularExpressionAttribute(string key)
            : base(FindRegex(key))
        { }
        private static string FindRegex(string key)
        {
            ...
        }
    }
