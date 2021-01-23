    public class Derived2 : Base
    { }
    IDerivedController x = ...
    IBaseController<IBase> y = x;
    y.DoSomething(new Derived2()); // oops! Derived2 doesn't implement IDerived
