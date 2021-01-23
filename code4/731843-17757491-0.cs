    class DbField : Attribute
    {
        public DbField(string source) { }
        
        public void GetInstance(PropertyInfo source)
        {
            Console.WriteLine(source.Name);
        }
    }
