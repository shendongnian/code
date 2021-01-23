    [System.Web.Services.WebMethod]
    public static void updatePSTNDataInDB(string args)
    {
      var serializer = new JavaScriptSerializer();
      Dictionary<string, string> jsonObjects = serializer.Deserialize<Dictionary<string, string>>(args);
             
      strSupplierOrderNo =  jsonObjects[strSupplierOrderNo];
    }
