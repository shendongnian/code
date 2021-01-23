    public class MyBaseClass
    {
        [NotMapped()]
        public virtual MyEnum MyEnum { get { return MyEnum.Base; } }
    }
    public class DerivedOne: MyBaseClass
    {
        public string OneProp { get; set; }
        public override MyEnum MyEnum { get { return MyEnum.One; } }
    }
    public class DerivedTwo: MyBaseClass
    {
        public string TwoProp { get; set; }
        public override MyEnum MyEnum { get { return MyEnum.Two; } }
    }
