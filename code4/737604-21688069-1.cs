    public static JObject JsonPostData(this Controller cntrlr)
    {
      //ensure we're at the start of the input stream
      Stream req = cntrlr.Request.InputStream;
      req.Seek(0, SeekOrigin.Begin);
    
      //read in any potential json
      string json = d2s.SafeTrim(new StreamReader(req).ReadToEnd());
      if (string.IsNullOrWhiteSpace(json)
        || !json.StartsWith("{")
        || !json.EndsWith("}"))
        return null;
    
      //try to deserialize it
      return JsonConvert.DeserializeObject(json) as JObject;
    }
    
    public static IEnumerable<JProperty> JsonPostProperties(this Controller cntrlr)
    {
      JObject jObj = cntrlr.JsonPostData();
      if (jObj == null) return null;
    
    
      return jObj.Properties();
    }
    
    public static IEnumerable<string> JsonPostPropNames(this Controller cntrlr)
    {
      IEnumerable<JProperty> jProps = cntrlr.JsonPostProperties();
      if (jProps == null) return null;
    
      return jProps.Select(O => O.Name);
    }
