    public class DoLazy
    {
        Lazy<int?> _field;
        public DoLazy()
        {
            // 'lazy' gets initialized - but `YourFieldInit` is not called yet.
            _field = new Lazy<int?>(() => YourFieldInit(""));
        }
        int Property
        {
            get
            {
                // `YourFieldInit` is called here, first time.
                return _field.Value ?? 0;
            }
        }
        int? YourFieldInit(string test)
        {   // breakpoint here
            return -1;
        }
        public static void Test()
        {
            var lazy = new DoLazy();
            int val1 = lazy.Property;
            var val = lazy.Property;
        }
    }
