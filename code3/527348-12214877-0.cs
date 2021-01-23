    public class MyBaseClass
    {
        public virtual int GetSomething()
        {
            throw new NotImplementedException();
        }
    }
    
    public class MyDerivedClass1 : MyBaseClass
    {
        public int SomeProperty { get; set; }
    
        public override int GetSomething()
        {
            return this.SomeProperty;
        }
    }
    
    public class MyDerivedClass2 : MyBaseClass
    {
        public int SomeOtherProperty { get; set; }
    
        public override int GetSomething()
        {
            return this.SomeOtherProperty;
        }
    }
