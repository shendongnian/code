        using System.Web.Script.Serialization;       
        ...
        public static T ParseResponse<T>(string data)
        {
            return new JavaScriptSerializer().Deserialize<T>(data);
        }
