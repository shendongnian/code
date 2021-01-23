    public static **string** GetTerminalBusinessTypes(string terminalID)
    ...
    var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    string sJSON = oSerializer.Serialize(results);
    return sJSON;
