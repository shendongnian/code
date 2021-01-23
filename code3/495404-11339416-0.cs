    public partial class Test
    {
        public string Name { get; set; }
    
        public Test(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    
    public partial class Test
    {
        public int Age { get; set; }
    
        public Test(string name)
        {
            Name = name;
        }
    }
