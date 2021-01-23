    public SomeObjectModel ParseJson(string IncomingJson)
    {
       JavascriptSerializer TheSerializer = new JavascriptSerializer();
       .....
    
       try
       {
           return TheSerializer.Deserialize<SomeObjectModel>(IncomingJson);
       }
       catch (Exception e)
       {
           throw new TheServerSentRubbishException(e);
       }
    }
