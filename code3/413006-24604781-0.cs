    internal class ParentClass
    {
        public string test()
        {
            return "This is the parent class function";
        }
        private class BaseChildClass
        {
            protected string childtest()
            {
                return "This is the parent class function";
            }
        }
    
        private class DerivedChildClass : BaseChildClass
        {
            private void askdjas()
            {
                string test = base.childtest();
                
            }
        }
    }
