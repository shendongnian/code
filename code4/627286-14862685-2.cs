    //You  will use the code like this:
    MyContainer container = new MyContainer();
    //setup interception for this type..
    container.SetupForInteception(typeof(IMyClass));
     //what happens here is you get a proxy class 
     //that intercepts every method call.
    IMyClass cls = container.Resolve<IMyClass>();
    
     //You need the following for it to work:   
    public class MyContainer: UnityContainer
    {
        public MyContainer()
        {
            this.AddNewExtension<Interception>();
            this.RegisterType(typeof(ICallHandler), 
                        typeof(LogCallHandler), "MyCallHandler");
            this.RegisterType(typeof(IMatchingRule), 
                           typeof(AnyMatchingRule), "AnyMatchingRule");
            this.RegisterType<IMyClass, MyClass>();
        }
        //apparently there is a new way to do this part
        // http://msdn.microsoft.com/en-us/library/ff660911%28PandP.20%29.aspx
        public void SetupForInteception(Type t)
        {
            this.Configure<Interception>()
            .SetInterceptorFor(t, new InterfaceInterceptor())
            .AddPolicy("LoggingPolicy")
            .AddMatchingRule("AnyMatchingRule")
            .AddCallHandler("MyCallHandler");
        }
    }
    //THIS will match which methods to log.
    public class AnyMatchingRule : IMatchingRule
    {
        public bool Matches(MethodBase member)
        {
            return true;//this ends up loggin ALL methods.
        }
    }
    public class LogCallHandler : ICallHandler
    {
        public IMethodReturn 
                 Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
          //All method calls will result in a call here FIRST.
          //IMethodInvocation has an exception property which will let you know
          //if an exception occurred during the method call.
        }
     }
