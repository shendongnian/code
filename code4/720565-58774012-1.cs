    internal class AnonymousGeneratedTypeName
    {
        private string name; // Actual field name is irrelevant
        private int    age;  // Actual field name is irrelevant
        public AnonymousGeneratedTypeName(string name, int age)
        {
            this.name = name; this.age = age;
        }
        
        public string Name { get { return name; } }
        public int    Age  { get { return age;  } }
        // The Equals and GetHashCode methods are overriden...
        // The ToString method is also overriden.
    }
    ...
    var dude = AnonymousGeneratedTypeName ("Bob", 23);
