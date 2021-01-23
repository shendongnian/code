    class Base
    {
       public virtual int MyProperty {get { return 1;} }   
    }
    class A: Base
    {
       public override int MyProperty { get { return 5; } }
    }
    class B: Base
    {
       public override int MyProperty { get { retun 7; } }
    }
