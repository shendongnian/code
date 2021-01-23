    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Type targetType = invocation.TargetType ?? invocation.Method.DeclaringType;
            ILog logger = LogManager.GetLogger(targetType);
            //Probably want to check logger.IsDebugEnabled
            if(invocation.Arguments.Count() == 0)
            {
                logger.DebugFormat("Method '{0}' called.", invocation.Method);
            }
            else
            {
                var stringBuilder = new StringBuilder("{" + invocation.Arguments.Length + "}");
                for (int i = invocation.Arguments.Length - 1; i > 0; i--)
                {
                    stringBuilder.Insert( 0, "{" + i + "}, " );
                }
                logger.DebugFormat("Method '{0}' called with parameters: " + stringBuilder, new[] { invocation.Method }.Union(invocation.Arguments).ToArray());
            }
            try
            {
                invocation.Proceed();
                if (invocation.Method.ReturnType != typeof(void))
                {
                    logger.DebugFormat("Method '{0}' returned: {1}", invocation.Method, invocation.ReturnValue);
                }
            }
            catch(Exception ex)
            {
                logger.Error(string.Format("Method '{0}' threw exception:", invocation.Method), ex);
                throw;
            }
        }
    }
