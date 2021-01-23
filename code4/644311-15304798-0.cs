    public ContentResult GetResult() 
    {
        var serializer = new JavaScriptSerializer();
        serializer.MaxJsonLength = Int32.MaxValue;
        var result = new ContentResult();
        result.Content = serializer.Serialize(data);
        result.ContentType = "text/json";
        return result;
    }
