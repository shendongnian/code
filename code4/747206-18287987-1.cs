    public class Wrapper : IInterceptor
    {
        object _lazy;
        protected readonly Type Type;
    
        public Wrapper(Type type)
        {
            Type = type;
        }
    
        public void Intercept(IInvocation invocation)
        {
            if (_lazy.IsNull()) // lazily instantiate the instance
            {
                _lazy = ObjectFactory.GetInstance(Type);
            }
            try
            {
                var method = invocation.Method;
                if (method.ContainsGenericParameters)
                {
                    method = method.MakeGenericMethod(invocation.GenericArguments);
                }
                invocation.ReturnValue = method.Invoke(_lazy, invocation.Arguments);
            }
            catch (TargetInvocationException ex)
            {
                // PublishingManager.Publish(.... // publish exception
                throw;
            }
        }
    }
