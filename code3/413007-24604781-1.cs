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
            private void test1()
            {
                string test = base.childtest();
                
            }
        }
    }
