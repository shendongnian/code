    public class MyInterceptor : IInterceptor
    {
        public Task Result { get; private set; }
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
                Result = (Task)invocation.ReturnValue;
            }
            catch (Exception ex)
            {
                var tcs = new TaskCompletionSource<object>();
                tcs.SetException(ex);
                Result = tcs.Task;
                throw;
            }
        }
    }
