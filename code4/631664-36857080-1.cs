    public static bool IsValidJson(this string input)
    {
        input = input.Trim();
        if ((input.StartsWith("{") && input.EndsWith("}")) || //For object
            (input.StartsWith("[") && input.EndsWith("]"))) //For array
        {
            try
            {
                //parse the input into a JObject
                var jObject = JObject.Parse(input);
    
                foreach(var jo in jObject)
                {
                    string name = jo.Key;
                    JToken value = jo.Value;
    
                    //if the element has a missing value, it will be Undefined - this is invalid
                    if (value.Type == JTokenType.Undefined)
                    {
                        return false;
                    }
                }
            }
            catch (JsonReaderException jex)
            {
                //Exception in parsing json
                Console.WriteLine(jex.Message);
                return false;
            }
            catch (Exception ex) //some other exception
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        else
        {
            return false;
        }
    
        return true;
    }
