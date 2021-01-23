        public class DoCheckInterceptor : IInterceptor
        {
             public void Intercept(IInvocation invocation)
             {
                //Do Work
                invocation.Proceed();
             }
        }
