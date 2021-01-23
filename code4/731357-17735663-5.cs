    public class IndexableClass
    {
        private string _abc = "hello world";
        public string VarName { get; set; }
        public string this[string name]
        {
            get 
            {
            switch (name)
            {
                // return known names
                case "abc" : return _abc;
                // by default, use reflection to check for any named properties
                default : 
                    PropertyInfo pi = typeof(IndexableClass).GetProperty(name);
                    if (pi != null) 
                    {
                        object value = pi.GetValue(this, null);
                        if (value is string) return value as string;
                        else if (value == null) return null;
                        else return value.ToString();
                    }
                    // if all else fails, throw exception
                    throw new InvalidOperationException("Property " + name + " does not exist!");
            }
            }
        }
    }
    static void Main()
    {
        var ArrayName = new IndexableClass();
        Console.WriteLine(ArrayName["ab" + "c"]);
    }
