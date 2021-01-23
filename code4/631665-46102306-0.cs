    using System.Web.Script.Serialization;
    bool IsValidJson(string json)
        {
            try {
                var serializer = new JavaScriptSerializer();
                dynamic result = serializer.DeserializeObject(json);
                return true;
            } catch { return false; }
        }
