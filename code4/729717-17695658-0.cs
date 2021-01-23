    public Articles function()
    {
        try
        {
            Articles articles = new Articles();
            articles.articleid = 234;
            articles.articlename = "Milk";
            articles.deleted = 0;
            //continue fill Articles 
            //and an exception occurs
            return articles;
        }
        catch (Exception e)
        {
            throw new WebFaultException(System.Net.HttpStatusCode.InternalServerError)
            {
                Message = e.Message
            };
        }
    }
