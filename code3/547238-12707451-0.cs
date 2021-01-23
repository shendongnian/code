    [TestMethod]
    public void Should_Wrap_Exception_ThrownByTarget()
    {
      var container = new UnityContainer();
      container.RegisterType<Target>(
        new Interceptor<VirtualMethodInterceptor>(), 
        new InterceptionBehavior<PolicyInjectionBehavior>());
      container.AddNewExtension<Interception>();
      var config = container.Configure<Interception>();
      config.AddPolicy("1").AddCallHandler<ExceptionHandler>().AddMatchingRule<AlwaysMatches>();
      var target = container.Resolve<Target>();
      target.AlwaysThrows("foo");
    }
    public class AlwaysMatches : IMatchingRule
    {
      public bool Matches(MethodBase member)
      {
        return true;
      }
    }
    public class ExceptionHandler : ICallHandler
    {
      public int Order { get; set; }
      public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
      {
        IMethodReturn r = getNext()(input, getNext);
        if (r.Exception != null)
        {
          throw new InvalidOperationException("CallHandler", r.Exception);
        }
        return r;
      }
    }
    public class Target
    {
      public virtual string AlwaysThrows(string foo)
      {
        throw new Exception("Boom!");
      }
    }
