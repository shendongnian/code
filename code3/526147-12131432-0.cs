    public class BaseClass {
      public virtual int SomeVirtualMethod() { return 1; }
    }
    public class DerivedClass : BaseClass {
      public override int SomeVirtualMethod() { return 2; }
    }
    BaseClass ref = new DerivedClass();
    int test = ref.SomeVirtualMethod(); // will be 2
