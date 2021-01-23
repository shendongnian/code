    string json = "{\"number\": 3, \"object\" : { \"t\" : 3, \"whatever\" : \"hi\", \"str\": \"test\"}}";
                var deserialized = JsonObject.Parse(json);
    
                var yourObject = deserialized.Get<IDictionary<string, object>>("object");
    
                if (yourObject != null)
                {
                    foreach (string key in yourObject.Keys)
                    {
                        var myValue = yourObject.GetValue(key);
                    }
                }
