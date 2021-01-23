    public bool TryParseJson(string IncomingJson, out SomeObjectModel theObjectModel)
    {
       JavascriptSerializer TheSerializer = new JavascriptSerializer();
       .....
    
       try
       {
           theObjectModel = TheSerializer.Deserialize<SomeObjectModel>(IncomingJson);
           return true;
       }
       catch (Exception e)
       {
           return false;
       }
    }
