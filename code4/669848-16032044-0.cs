    public static class StringExtensions {
    
       private static readonly NameConvert = new Regex(@"((?<=[a-z])[A-Z]|(?<!^|\s)[A-Z](?=[a-z]))");
    
       public static string ToDisplayFormat(this string name) {
         return string.IsNullOrEmpty(name) ? 
           String.Empty :
           NameConvert.Replace(source," $1");
       }
    }
