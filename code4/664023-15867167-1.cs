    class IgnoreExceptionsInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                invocation.ReturnValue = GetDefault(invocation.Method.ReturnType);
            }
        }
        private static object GetDefault(Type type)
        {
            if (type.IsValueType && type != typeof(void))
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
    }
