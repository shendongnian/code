    public class A_B
    {
        [Key, ForeignKey("A"), Column(Order = 1)]
        public int AId { get; set; }
        [Key, ForeignKey("B"), Column(Order = 2)]
        public int BId { get; set; }
        public A A { get; set; }
        public B B { get; set; }
        public int SortOrder { get; set; }
    }
