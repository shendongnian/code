           var array = result["items"].Value<JArray>();
            IList collection = (IList)array;
 
            var list = new List<string>();
            for (int i = 0; i < collection.Count; j++)
                {
                  list.Add(collection[i].ToString());             
                }                         
