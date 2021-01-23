    public static class ExceptionExtensions
    {
        public static IEnumerable<Exception> InnerExceptions(this Exception exception)
        {
            Exception ex = exception;
            while (ex != null)
            {
                yield return ex;
                ex = ex.InnerException;
            }
        }
    }
