    public interface IBaseClass
    {
        void BaseMethod1();
        void BaseMethod2();
    }
    public class BaseClass : IBaseClass
    {
        public void BaseMethod1()
        {
        }
        public void BaseMethod2()
        {
        }
    }
    public class MiddleClass : IBaseClass
    {
        BaseClass @base;
        public MiddleClass() { this.@base=new BaseClass(); }
        public void MiddleMethod()
        {
            @base.BaseMethod1();
        }
        void IBaseClass.BaseMethod1()
        {
            @base.BaseMethod1();
        }
        public void BaseMethod2()
        {
            @base.BaseMethod2();
        }
    }
    public class ClientClass : MiddleClass
    {
        public void Test()
        {
            this.MiddleMethod();
            // 'ClientClass' does not contain a definition for 'BaseMethod1'
            //this.BaseMethod1(); 
        }
    }
