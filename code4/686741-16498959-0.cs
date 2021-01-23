    class BaseClass
    {
        public BaseClass()
        {
            this.Initialize();
        }
        protected virtual void Initialize()
        {
            System.Console.WriteLine("This should be shown after");
        }
    }
    class DerivedClass : BaseClass
    {
        public DerivedClass() : base()
        {
        }
        protected override void Initialize()
        {
            System.Console.WriteLine("This should be shown first");
            base.Initialize();
        }
    }
