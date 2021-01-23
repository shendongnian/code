    public class Test
    {
        public string Name { get; set; }
        public Test Copy()
        {
            return (Test)this.MemberwiseClone();
        }
    }
