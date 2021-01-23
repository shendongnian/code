    public class Test
    {
        public int Age { get; set; }
        public string Name { get; set; }
    
        public Test(string name)
        {
            Name = name;
        }
    
        public Test(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
