    string text = 
    @"namespace X {
        public class MyClass {
            //Text here
        }
    }";
            
    var modified = Regex.Replace(text, @"( *)((public?)\s*(static)?\s*class\s+[^{]+{)", "$1$2\r\n\r\n$1    public string MyProperty { get; set; }");
    Console.WriteLine(modified);
