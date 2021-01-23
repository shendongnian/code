    public class ObjectA
    {
        public Guid Id {get; set;}
        public virtual ObjectB Objectb {get; set;}
    }
    public class ObjectB
    {
        public Guid Id {get; set;}
        public virtual ObjectA ObjectA {get; set;}
    }
