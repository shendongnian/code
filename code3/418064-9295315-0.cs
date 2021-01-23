        public partial class MyClass
        {
            public void NonSensitive(){}
        }
    
        #if INTERNAL_BUILD
        public partial class MyClass
        {
            public void Sensitive(){}
        }
        #endif
