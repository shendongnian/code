    public class LoggingProxy<T> : RealProxy
    {
        private readonly T _instance;
        private LoggingProxy(T instance)
            : base(typeof(T))
        {
            _instance = instance;
        }
        public static T Create(T instance)
        {
            return (T)new LoggingProxy<T>(instance).GetTransparentProxy();
        }
        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = (IMethodCallMessage)msg;
            var method = (MethodInfo)methodCall.MethodBase;
            try
            {
                Console.WriteLine("Before invoke: " + method.Name);
                var result = method.Invoke(_instance, methodCall.InArgs);
                Console.WriteLine("After invoke: " + method.Name);
                return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
                if (e is TargetInvocationException && e.InnerException != null)
                {
                    return new ReturnMessage(e.InnerException, msg as IMethodCallMessage);
                }
                return new ReturnMessage(e, msg as IMethodCallMessage);
            }
        }
    }
