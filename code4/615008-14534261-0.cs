    private static readonly JavaScriptSerializer _serializer = Json.CreateSerializer();
    public static string Encode(object value)
    {
      DynamicJsonArray dynamicJsonArray = value as DynamicJsonArray;
      if (dynamicJsonArray != null)
        return Json._serializer.Serialize((object) (object[]) dynamicJsonArray);
      else
        return Json._serializer.Serialize(value);
    }
