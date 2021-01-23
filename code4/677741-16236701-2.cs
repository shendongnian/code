    public class BaseClass
    {
        protected void BaseMethod1()
        {
        }
        public void BaseMethod2()
        {
        }
    }
    public class MiddleClass : BaseClass
    {
        public void MiddleMethod()
        {
        }
        // hide method
        private void BaseMethod1()
        {
           base.BaseMethod1();
        }
    }
