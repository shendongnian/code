    class Base
    {
        public virtual string GetName()
        {
            return MethodBase.GetCurrentMethod().DeclaringType.ToString();
        }
    }
    
    class A : Base
    {
        public override string GetName()
        {
            return base.GetName() + "." + MethodBase.GetCurrentMethod().DeclaringType.ToString();
            
        }
    }
    
    class B : A
    {
        public override string GetName()
        {
            return base.GetName() + "." + MethodBase.GetCurrentMethod().DeclaringType.ToString();
        }
    }
    
    class C : B
    {
        public override string GetName()
        {
            return base.GetName() + "." + MethodBase.GetCurrentMethod().DeclaringType.ToString();
        }
    }
    
    C test = new C();
    test.GetName(); // Yields "Base.A.B.C"
