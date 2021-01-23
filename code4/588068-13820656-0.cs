    public class Parent
    {
        public virtual Child Child { get; set; }
    }
    
    public class Child
    {
        public virtual int Key1 { get; set; } //composite primary key
        public virtual int Key2 { get; set; } //composite primary key
        public virtual string SomeDescription { get; set;}
    }
    // in ParentMap
    References(p => p.Child).Columns.Add("child_key1", "child_key2");
    // in Child
    CompositeId()
        .KeyProperty(x => x.Key1)
        .KeyProperty(x => x.Key2);
