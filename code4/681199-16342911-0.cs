    static Stream ToJson(object o)
    {
        var result = JsonConvert.SerializeObject(o);
        var data = Encoding.UTF8.GetBytes(result);
        WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
        WebOperationContext.Current.OutgoingResponse.ContentLength = data.Length;
        return new MemoryStream(data);
    }
