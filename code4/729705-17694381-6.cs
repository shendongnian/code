    public IList<Articles> GetArticles()
    {
        try
        {
            return GetSomeArticlesFromDatabase();
        }
        catch (Exception innerException)
        {
            throw new MyCustomException("some data", 500, innerException);
        }
    }
    public class MyCustomException : Exception
    {
        public int HttpCode { get; set; }
        public MyCustomException(string errorMessage, int httpCode, Exception innerException)
            : base(errorMessage, innerException) {
                HttpCode = httpCode;
        }
    }
    public void EntryPoint()
    {
        try
        {
            DoSomething();
            var result = GetArticles();
            DoSomething();
            DisplayResult(result);
        }
        catch (MyCustomException ex)
        {
            ReturnHttpError(ex.Message, ex.HttpCode);
        }
    }
