    class a
    {
       public virtual void method1()
       {
       }
        
       public string property1 { get; set; }
    }
        
    class b : a
    {
        // this has it's own instance in b, the only way to get to
        // the original property1 is with base (or reflection)
        public new string property1 { get; set; }
        public override void method1()
        {
           // the only way to get to the original method1 and property1
           base.method1();
           base.property1 = "string";
        }
    }
