    public SomeObjectModel ParseJsonIfValid(string IncomingJson)
    {
       SomeObjectModel TheObjectModel = new SomeObjectModel();
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
