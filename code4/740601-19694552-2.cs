    public class X
    {
        public int ID { get; set; } 
        public string Value { get; set; }
        public int YID { get; set; }
        public virtual ICollection<Y> Ys { get; set; }
    }
    public class Y
    {
        public int ID { get; set; } 
        public string Value { get; set; }
        public virtual ICollection<X> Xs{ get; set; }
    }
