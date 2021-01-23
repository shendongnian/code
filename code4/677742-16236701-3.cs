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
           base.BaseMethod1();
        }
        // hide method
        private new void BaseMethod1()
        {
           
        }
    }
