    public class X
    {
        [Key, ForeignKey("Y"), Column(Order=0)]
        public int ID { get; set; }
        [Key, ForeignKey("Y"), Column(Order=1)]
        public int line { get; set; }
        public virtual Y Y { get; set; }
    }
    public class Y
    {
        [Key, Column(Order=0)]
        public int ID { get; set; }
        [Key, Column(Order=1)]
        public int line { get; set; }
        public virtual X X { get; set; }
    }
