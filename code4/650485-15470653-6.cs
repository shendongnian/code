    string text = 
    @"namespace X {
        public class MyClass {
            //Text here
        }
    }";
    string className = "MyClass";
    string propertyType = "string";
    string propertyName = "MyProperty";
    string regex = string.Format(@"( *)((public?)\s*(static)?\s*class\s+{0}[^{{]+{{)", className);
    string replacement = string.Format("$1$2\r\n\r\n$1    public {0} {1} {{ get; set; }}", propertyType, propertyName);
    
    var modified = Regex.Replace(text, regex, replacement);
    Console.WriteLine(modified);
