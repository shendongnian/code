    public class Leaf1
    {
        public virtual int ID { get; set; }
        public virtual string Info1 { get; set; }
        public virtual string Info2 { get; set; }
        public virtual RootTable Parent { get; set; }
        public virtual int ParentId { get; set; }
    }
