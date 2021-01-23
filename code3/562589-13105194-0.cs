    class BaseClass {
        public void MethodOfInterest() {
        }
        public BaseClass(string p) {
            MethodOfInterest();
        }
    }
    class DerivedClass : BaseClass {
        // MethodOfInterest will be called as part
        // of calling the DerivedClass constructor
        public DerivedCLass(string p) : base(p) {
        }
    }
