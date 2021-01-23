    public class Arbitrary2 : Arbitrary {
        public IFoo GetDerived() {
            return base.GetBase() as IFoo;
        }
    }
