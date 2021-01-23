    public class A
    {
        [MyAttribute1]
        public virtual string field { get; set; }
    }
    public class B : A
    {
        [MyAttribute2]
        [MyAttribute3]
        public override string field { get; set; }
    }
