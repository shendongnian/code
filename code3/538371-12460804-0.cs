    public interface IProxy
    {
        void Foo();
    }
    public class Proxy1 : IProxy
    {
        public void Foo()
        {
        }
    }
    public class Proxy2 : IProxy
    {
        public void Foo()
        {
        }
    }
    static class Helper
    {
        public static IProxy GetProxyInstance(int i)
        {
            if (i == 1)
            {
                return new Proxy1();
            }
            else if (i == 2)
            {
                return new Proxy1();
            }
            else
            {
                return null;
            }
        }
    }
    class BusinessClass
    {
        public void bar()
        {
            IProxy proxyObj = Helper.GetProxyInstance(1);
            proxyObj.Foo();
        }
    }
