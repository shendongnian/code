    public class System
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    
    public class Jumplane
    {
        public int ID { get; set; }
        public virtual System System1 { get; set; }
        public virtual System System2 { get; set; }
    }
