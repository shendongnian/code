    using System;
    using AopAlliance.Intercept;
    using NUnit.Framework;
    using Spring.Aop.Framework;
    
    namespace Aop
    {
    
        [TestFixture]
        public class SimpleProxyFactoryTests
        {
            [Test]
            public void Main()
            {
                var host = new Host();
    
                var mp = new SimplePlugin(); 
                var pf = new ProxyFactory(mp);
                pf.AddAdvice(new DelegateToHostExceptionHandlingAdvice(host));
    
                var proxy = (IPlugin)pf.GetProxy();
    
                proxy.DoWork();
            }
        }
    
        public interface IPlugin
        {
            void DoWork();
        }
    
        public class Host
        {
            public void HandleExceptionFromPlugin(Exception ex)
            {
                Console.WriteLine("Handling exception: {0}", ex.Message);
            }
        }
    
        public class SimplePlugin : IPlugin
        {
            public void DoWork()
            {
                Console.WriteLine("Doing it and throwing an exception ... ");
    
                throw new ApplicationException("Oops!");
            }
        }
    
        public class DelegateToHostExceptionHandlingAdvice : IMethodInterceptor 
        {
            private readonly Host _host;
    
            public DelegateToHostExceptionHandlingAdvice(Host host)
            {
                _host = host;
            }
    
            public object Invoke(IMethodInvocation invocation)
            {
                try
                {
                    return invocation.Proceed();
                }
                catch (Exception ex)
                {
                     _host.HandleExceptionFromPlugin(ex);
                    return null; 
                }
            }
        }
    }
