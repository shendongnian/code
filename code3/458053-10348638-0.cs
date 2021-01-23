    [Serializable]
    public class RetryOnExceptionAspect : MethodInterceptionAspect
    {
        private readonly int maxRetries;
        private readonly Type exceptionType;
        public RetryOnExceptionAspect(int maxRetries, Type exceptionType)
        {
            this.maxRetries = maxRetries;
            this.exceptionType = exceptionType;
        }
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            for (int i = 0; i < maxRetries + 1; i++)
            {
                try
                {
                    args.Proceed();
                }
                catch (Exception e)
                {
                    if (e.GetType() == exceptionType && i < maxRetries)
                    {
                        continue;
                    }
                    throw;
                }
                break;
            }
        }
    }
