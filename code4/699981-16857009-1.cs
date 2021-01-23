       public static string GetJSON(object obj)
        {
            var oSerializer = new JavaScriptSerializer();
            var sbJsonResults = new StringBuilder();
            oSerializer.Serialize(obj, sbJsonResults);
            return sbJsonResults.ToString();
        }
