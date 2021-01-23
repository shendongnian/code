    public class Definition
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public override string ToString()
        {
            return Name + "\tdef: " + Value;   
        }
    }
