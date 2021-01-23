    public static class ExceptionExtensions
    {
        public static string GetMessageWithInner(this Exception ex) =>
            string.Join($";{ Environment.NewLine }caused by: ",
                GetInnerExceptions(ex).Select(e => $"'{ e.Message }'"));
        public static IEnumerable<Exception> GetInnerExceptions(this Exception ex)
        {
            while (ex != null)
            {
                yield return ex;
                ex = ex.InnerException;
            }
        }
    }
