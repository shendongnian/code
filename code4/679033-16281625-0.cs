    public class DerivedClass : BaseClass
    {
        // hides the base method (basically you're hijacking the signature)
        public new string GetSomeValue() { return "derived class"; }
    }
