    public class MyClass
    {
        public string Name { get; set; }
        public List<MyClass> MyClasses { get; set; }
        public MyClass(string name)
        {
            Name = name;
            MyClasses = new List<MyClass>();
        }
    }
