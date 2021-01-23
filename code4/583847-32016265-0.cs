    public abstract class RuntimeProxy
    {
        public static readonly object Default = new object();
    
        public static Target Create<Target>(Target instance, RuntimeProxyInterceptor interceptor) where Target : class
        {
            return (Target)new InternalProxy<Target>(instance, interceptor).GetTransparentProxy();
        }
    
        public static Target Create<Target>(Target instance, Func<RuntimeProxyInvoker, object> factory) where Target : class
        {
            return (Target)new InternalProxy<Target>(instance, new InternalRuntimeProxyInterceptor(factory)).GetTransparentProxy();
        }
    
    
        class InternalProxy<Target> : RealProxy where Target : class
        {
            readonly object Instance;
            readonly RuntimeProxyInterceptor Interceptor;
    
            public InternalProxy(Target instance, RuntimeProxyInterceptor interceptor)
                : base(typeof(Target))
            {
                Instance = instance;
                Interceptor = interceptor;
            }
    
            public override IMessage Invoke(IMessage msg)
            {
                var methodCall = (IMethodCallMessage)msg;
                var method = (MethodInfo)methodCall.MethodBase;
    
                try
                {
                    var result = Interceptor.Invoke(new InternalRuntimeProxyInterceptorInvoker(Instance, method, methodCall.InArgs));
    
                    if (result == RuntimeProxy.Default)
                        result = method.ReturnType.IsPrimitive ? Activator.CreateInstance(method.ReturnType) : null;
    
                    return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
                }
                catch (Exception ex)
                {
                    if (ex is TargetInvocationException && ex.InnerException != null)
                        return new ReturnMessage(ex.InnerException, msg as IMethodCallMessage);
    
                    return new ReturnMessage(ex, msg as IMethodCallMessage);
                }
            }
        }
    
        class InternalRuntimeProxyInterceptor : RuntimeProxyInterceptor
        {
            readonly Func<RuntimeProxyInvoker, object> Factory;
    
            public InternalRuntimeProxyInterceptor(Func<RuntimeProxyInvoker, object> factory)
            {
                this.Factory = factory;
            }
    
            public override object Invoke(RuntimeProxyInvoker invoker)
            {
                return Factory(invoker);
            }
        }
    
        class InternalRuntimeProxyInterceptorInvoker : RuntimeProxyInvoker
        {
            public InternalRuntimeProxyInterceptorInvoker(object target, MethodInfo method, object[] args)
                : base(target, method, args)
            { }
        }
    }
    
    public abstract class RuntimeProxyInterceptor
    {
        public virtual object Invoke(RuntimeProxyInvoker invoker)
        {
            return invoker.Invoke();
        }
    }
    
    public abstract class RuntimeProxyInvoker
    {
        public readonly object Target;
        public readonly MethodInfo Method;
        public readonly ReadOnlyCollection<object> Arguments;
    
        public RuntimeProxyInvoker(object target, MethodInfo method, object[] args)
        {
            this.Target = target;
            this.Method = method;
            this.Arguments = new ReadOnlyCollection<object>(args);
        }
    
        public object Invoke()
        {
            return Invoke(this.Target);
        }
    
        public object Invoke(object target)
        {
            if (target == null)
                throw new ArgumentNullException("target");
    
            try
            {
                return this.Method.Invoke(target, this.Arguments.ToArray());
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }
    }
