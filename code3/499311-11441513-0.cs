    public class Arbitrary2 : Arbitrary {
        public IFoo GetDerived() {
            return (Derived)this.GetBase();
        }
    }
