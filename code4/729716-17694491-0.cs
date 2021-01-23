    public class InvalidArticleException: Exception {
        public string ExceptionMessage { get; set; }
        public string ExceptionName { get; set; }
        public int HttpCode { get; set; }
    }
    public **** function()
    {
        try
        {
            // DO STUFF
            return articles;
        }
        catch (InvalidArgumentException e)
        {
            throw new InvalidArticleException() {
                ExceptionMessage = e.Message,
                ExceptionName = e.ToString(),
                HttpCode = 500
            }
        }
        catch (Exception ex) {   // Not actually required; left in for future debugging
           throw ex;             
        }
    }
