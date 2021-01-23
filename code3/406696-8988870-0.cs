    public class Constants
    {
        public const string test1 = "This is testvalue1";
        public const string test2 = "This is testvalue1";
        public const string test3 = "This is testvalue1";
        public const string test4 = "This is testvalue1";
        public const string test5 = "This is testvalue1";
    
        public static string Get(string propertyName)
        {
          var value = (string)(typeof(Constants).GetField(propertyName,BindingFlags.Static | BindingFlags.Public).GetValue(null));
          return value;
        }
    }
