    class Base {
       public virtual string GetName() { return "Base"; }
    }
    
    class A : Base {
       public override string GetName() { return base.GetName() + ".A"; }
    }
    
    class B : A  {
       public override string GetName() { return base.GetName() + ".B"; }
    }
