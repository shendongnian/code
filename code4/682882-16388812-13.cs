    public class A
    {
        public int AId { get; set; }
        public ICollection<A_B> A_Bs { get; set; }
    }
    public class B
    {
        public int BId { get; set; }
        public ICollection<A_B> A_Bs { get; set; }
    }
