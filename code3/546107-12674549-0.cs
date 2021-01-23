    public class ZeroObject
    {
        public ZeroObject (string name)
        {
            Name = name;
        }
        public ZeroObject Parent { get; set }
        public string Name { get; private set; }
    }
