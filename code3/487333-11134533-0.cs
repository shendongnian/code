    public class MyClass
    {
        String Template;
        String Term;
        public List<KeyValuePair<string, string>> Attributes { get; private set; }
    
        public MyClass() {
            Attributes = new List<KeyValuePair<string, string>();
        }
        public void AddAttribute(string key, string value) {
            Attributes.Add(new KeyValuePair<string, string>(key, value));
        }
    }
    
    // to be used like this: 
    MyClass instance = new MyClass();
    instance.AddAttribute("Email", "test@example.com");
    instance.AddAttribute("Phone", "555-1234");
