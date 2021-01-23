    public class MyClass
    {
        public Category Category { get; set; }
    }
    
    public class Category
    {
        public Category(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
