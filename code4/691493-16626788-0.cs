    public class A
    {
        public int AId { get; set; }
        public int PropertyA1 { get; set; }
        public string PropertyA2 { get; set; }
        public DateTime PropertyA3 { get; set; }
        
        public ICollection<B> Bs { get; set; }
    }
    public class B
    {
        public int BId { get; set; }
        // ...
        
        public ICollection<A> As { get; set; }
    }
