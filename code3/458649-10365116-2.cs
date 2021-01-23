    public class LoggingInterceptor : IInterceptor
    {
        // No matter what service method is called, it's funneled through here.
        public void Intercept(IInvocation call)
        {
            MyLogger.Info("Starting call: " + call.Method.Name);
            // Actually invoke whatever method was originally called 
            call.Proceed();
            MyLogger.Info("Finished call: " + call.Method.Name);
        }
    }
