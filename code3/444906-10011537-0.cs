     protected static string JsonSerialize(Object obj)
     {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer { MaxJsonLength = int.MaxValue };
            var json = serializer.Serialize(obj);
            return json;
      }
