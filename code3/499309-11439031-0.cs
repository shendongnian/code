    public class Arbitrary2 : Arbitrary {
        public IFoo GetDerived() {
            return (IFoo)(Derived)base.GetBase();
        }
    }
