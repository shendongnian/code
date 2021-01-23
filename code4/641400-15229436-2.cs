    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.InterceptionExtension;
    using System;
    
    namespace InterceptSetter
    {
        class Program
        {
            static void Main(string[] args)
            {
                UnityContainer container = new UnityContainer();
    
                container.AddNewExtension<Interception>();
                container.RegisterType<ISomeObject, SomeObject>(
                          new Interceptor<TransparentProxyInterceptor>(),
                          new InterceptionBehavior<SetterCallsFilterMethodBehavior>());
                
                // we must get our instance from unity for interception to occur
                ISomeObject myObject = container.Resolve<ISomeObject>();
                myObject.SomeProperty = "Hello Setter";
    
                Console.ReadLine();
            }
        }
    }
