    using using System.Web.Script.Serialization;
    // .....
        public object GetJson(string url)
        {
            var json = Get(url); // I have code that makes this work, it gets a JSON string
            try
            {
                var deserializer = new JavaScriptSerializer();
                var result = deserializer.DeserializeObject(json);
                return result;
            }
            catch (ArgumentException e)
            {
                // Error handling....
            }            
        }
