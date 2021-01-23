    public List<APITicket> JsonParser(string json)   
        {
            Newtonsoft.Json.Linq.JArray jArray = Newtonsoft.Json.Linq.JArray.Parse(json);
            
            var list = new List<APITicket>();
            
            foreach(var item in jArray)
            {
                list.Add(
                    new APITicket { location = item["APITicket"]["location"],
                                    ticket =   item["APITicket"]["ticket"]            
                    }
                );
            }
            return list;
        }
