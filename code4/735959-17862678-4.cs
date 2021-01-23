    [System.Web.Services.WebMethod]
    public static Dictionary<string, string> getNameValue(string name, string keyN) 
    {
      var schemaName = name;
      var key = keyN;
    
      Loader loader = ConnectionManager.getLoader();
      Dictionary<string, string> name_value = new Dictionary<string, string>();
      if (!string.IsNullOrEmpty(schemaName))
      {
        var schema = loader.GetSchema(schemaName);
        var qcontext = new SimpleLoader.BOService.QueryContext();
        qcontext.InitQueryContext();
    
        var element = loader.GetObjectByKey(schema, key);
        var viselems = element._Schema.GetVisibleElems(); 
        var cardElems = viselems.Where(x => !(x is SchemaElemDetail)).ToList();
    
        foreach (var elem in cardElems)
        {
          var value = (element.GetValue(elem.Name) ?? "").ToString();
          if (!string.IsNullOrEmpty(value))
          {
             name_value.Add(elem.Name, value);
          }
        }    
      }
      return name_value; //will be automatically serialised to JSON because of the dataType specification in ajax call.
    }
