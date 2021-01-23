    public class MyClass
    {
        public static MyClass Parse(string input)
        {
            if(String.IsNullOrWhiteSpace(input)) throw new ArgumentException(input);
            var instance = new MyClass();
            // Parse the string and populate the MyClass instance
            
            return instance;
        }
    }
