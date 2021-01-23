    class A_Content {  public virtual string Bar {get;set;} }
    
    class B_Content : A_Content
    {
        public override string Bar {get;set;};
    }
    
    class C_Content : A_Content
    {
        public override string Bar {get;set};
    }
