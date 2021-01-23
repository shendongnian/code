    public class Test
    {
        private static Random r = new Random();
        public Test (string name)
        {
            Name = name;
            Age = r.Next(16, 45);
        }
    
        public string Name { get; set; }
    
        public int Age{ get; set; }
    }
