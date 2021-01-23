    // Assumes the method returns a plain Task
    public class MyInterceptor : IInterceptor
    {
        private static async Task InterceptAsync(Task originalTask)
        {
            // Await for the original task to complete
            await originalTask;
            // asynchronous post-execution
            await Task.Delay(100);
        }
        public void Intercept(IInvocation invocation)
        {
            // synchronous pre-execution can go here
            invocation.Proceed();
            invocation.ReturnValue = InterceptAsync((Task)invocation.ReturnValue);
        }
    }
