    internal class WcfCallInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                RaiseStart(invocation.Method.Name);
                invocation.Proceed();
            }
            finally
            {
                RaiseEnd(invocation.Method.Name);
            }
        }
        
        //you can define your implementation for RaiseStart and RaiseEnd
        
     }
