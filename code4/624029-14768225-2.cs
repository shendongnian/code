    public SomeObjectModel ParseJsonIfValid(string IncomingJson)
    {
       JavascriptSerializer TheSerializer = new JavascriptSerializer();
       .....
    
       try
       {
           return TheSerializer.Deserialize<SomeObjectModel>(IncomingJson);
       }
       catch
       {
           return null;
       }
    }
