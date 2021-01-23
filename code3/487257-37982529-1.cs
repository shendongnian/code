            Dictionary<string, object> JSONDic = new Dictionary<string, object>();
            JavaScriptSerializer js = new JavaScriptSerializer();
            
              try {
                JSONDic = js.Deserialize<Dictionary<string, object>>(inString);
                JSONDeserialized = "";
                
                indentLevel = 0;
                DisplayDictionary(JSONDic); 
                return JSONDeserialized;
            
            }
            catch (Exception)
            {
                return "Could not parse input JSON string";
            }
            
