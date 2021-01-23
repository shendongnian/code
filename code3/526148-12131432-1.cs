    public class BaseClass {
      public int SomeMethod() { return 1; }
    }
    public class DerivedClass : BaseClass {
      public new int SomeMethod() { return 2; }
    }
    BaseClass ref = new DerivedClass();
    int test = ref.SomeMethod(); // will be 1
    DerivedClass ref2 = ref;
    int test2 = ref2.SomeMethod(); // will be 2
