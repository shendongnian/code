    public class LoggingInterceptor : IInterceptor
    {
        private readonly ILoggerFactory _loggerFactory;
        public LoggingInterceptor(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Intercept(IInvocation invocation)
        {
            var logger = _loggerFactory.Create(invocation.TargetType);
            if (logger.IsDebugEnabled)
            {
                logger.Debug(CreateInvocationLogString(invocation));
            }
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                logger.Warn(CreateInvocationLogString(invocation));
                throw;
            }
            logger.Info(CreateInvocationLogString(invocation));
        }
        private static String CreateInvocationLogString(IInvocation invocation)
        {
            var sb = new StringBuilder(100);
            sb.AppendFormat("Called: {0}.{1}(", invocation.TargetType.Name, invocation.Method.Name);
            foreach (var argument in invocation.Arguments)
            {
                var argumentDescription = argument == null ? "null" : argument.ToString();
                sb.Append(argumentDescription).Append(",");
            }
            if (invocation.Arguments.Any())
            {
                sb.Length--;
            }
            sb.Append(")");
            return sb.ToString();
        }
    }
