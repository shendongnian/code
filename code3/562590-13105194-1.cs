    class BaseClass {
        public void MethodOfInterest() {
        }
        // By declaring a constructor explicitly, the default "0 argument"
        // constructor is not automatically created for this type.
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
