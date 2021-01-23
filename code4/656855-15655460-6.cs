     string json = "{\"number\": 3, \"object\" : { \"t\" : 3, \"whatever\" : \"hi\", \"str\": \"test\"}}";
                var deserialized = SimpleJson.DeserializeObject<IDictionary<string, object>>(json);
    
                var yourObject = deserialized["object"] as IDictionary<string, object>;            
                if (yourObject != null)
                {
                    var tValue = yourObject.GetValue("t");
                    var whateverValue = yourObject.GetValue("whatever");
                    var strValue = yourObject.GetValue("str");
                } 
     public static object GetValue(this IDictionary<string,object> yourObject, string propertyName)
            {
                return yourObject.FirstOrDefault(p => p.Key == propertyName).Value;
            }
