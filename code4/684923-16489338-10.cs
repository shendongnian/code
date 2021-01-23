    public static class JSONHelper
        {
            public static string ToJSON(this System.Web.Mvc.FormCollection collection)
            {
                var list = new Dictionary<string, string>();
                foreach (string key in collection.Keys)
                {
                    list.Add(key, collection[key]);
                }
                return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list);
            }
        }
