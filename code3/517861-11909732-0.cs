    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.InterceptionExtension;
    using NUnit.Framework;
    
    namespace UnitTests
    {
        [TestFixture]
        public class ForTest
        {
            [Test]
            public void Test()
            {
                IUnityContainer container = new UnityContainer().AddNewExtension<Interception>();
                container.RegisterType<IMyInterface, SpecificClass1>(
                    new Interceptor<InterfaceInterceptor>(),
                    new InterceptionBehavior<MyInterceptionBehavior>());
                var myInterface = container.Resolve<IMyInterface>();
                myInterface.SomeMethod();
            }
        }
    
        public interface IMyInterface
        {
            void SomeMethod();
        }
    
        public class SpecificClass1 : IMyInterface
        {
            #region IMyInterface
    
            public void SomeMethod()
            {
                Console.WriteLine("Method Called");
            }
    
            #endregion
        }
    
        public class MyInterceptionBehavior : IInterceptionBehavior
        {
            public bool WillExecute
            {
                get { return true; }
            }
    
            #region IInterceptionBehavior
    
            public IEnumerable<Type> GetRequiredInterfaces()
            {
                return Enumerable.Empty<Type>();
            }
    
            public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
            {
                IMethodReturn result = getNext()(input, getNext);
                Console.WriteLine("Interception Called");
                return result;
            }
    
            #endregion
        }
    }
