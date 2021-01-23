    public ContentResult Save(string json)
    {
        try
        {
            dynamic data = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<dynamic>(json);
        }
        catch (Excepteion ex)
        {
             // More code
        }
    }
