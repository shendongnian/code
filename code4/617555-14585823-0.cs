    public class AddServer
    {
        public AddServer(string name, string seed, List<string> ops)//constructor
        {
            Ops = ops;
            Seed = seed;
            Name = name;
        }
    
        public string Name { get; private set; }
        public string Seed { get; private set; }
        public List<string> Ops { get; private set; } 
    }
