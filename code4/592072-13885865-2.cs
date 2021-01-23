    public class A
    {
        public A()
        {
            Initialize();
        }
        private void Initialize()
        {
            // Initialize the base class A.
            
            // Then call DerivedInitialize. If this is actually a derived object,
            // DerivedInitialize will initialize the derived instance. Otherwise,
            // it won't do anything.
            DerivedInitialize();
        }
        protected virtual void DerivedInitialize()
        {
        }
    }
    public class B : A
    {
        public B()
        {
            Initialize();
        }
        protected override void DerivedInitialize()
        {
            // Initialize B-specific stuff...
        }
    }
