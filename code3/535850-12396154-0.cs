    public class ObjectA
    {
        public Languague Languague {get;set;}
        public int Id {get;set;}
        ... // and a list of objectA properties
        public virtual ICollection<ObjectB> ObjectBs {get;set;}
    }
    public class ObjectB
    {
        public Languague Languague {get;set;}
        public int Id {get;set;}
        ... // and a list of objectB properties
        public int TheObjectAId {get;set;}
        public ObjectA TheObjectA {get;set;}
    }
