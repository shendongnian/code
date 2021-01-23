     public static class ExtensionMethods
    {
        public static string GetQueryString(this object obj, string prefix = "")
        {
            var query = "";
            try
            {
                var vQueryString = (JsonConvert.SerializeObject(obj));
                var jObj = (JObject)JsonConvert.DeserializeObject(vQueryString);
                query = String.Join("&",
                   jObj.Children().Cast<JProperty>()
                   .Select(jp =>
                   {
                       if (jp.Value.Type == JTokenType.Array)
                       {
                           var count = 0;
                           var arrValue = String.Join("&", jp.Value.ToList().Select<JToken, string>(p =>
                           {
                               var tmp = JsonConvert.DeserializeObject(p.ToString()).GetQueryString(jp.Name + HttpUtility.UrlEncode("[") + count++ + HttpUtility.UrlEncode("]"));
                               return tmp;
                           }));
                           return arrValue;
                       }
                       else
                           return (prefix.Length > 0 ? prefix + HttpUtility.UrlEncode("[") + jp.Name + HttpUtility.UrlEncode("]") : jp.Name) + "=" + HttpUtility.UrlEncode(jp.Value.ToString());
                   }
                   )) ?? "";
            }
            catch (Exception ex)
            {
            }
            return query;
        }
    }
