    public class MyContainer: UnityContainer
    {
        public MyContainer()
        {
            this.AddNewExtension<Interception>();
            this.RegisterType(typeof(ICallHandler), 
                        typeof(LogCallHandler), "MyCallHandler");
            this.RegisterType(typeof(IMatchingRule), 
                           typeof(AnyMatchingRule), "AnyMatchingRule");
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
        }
     }
