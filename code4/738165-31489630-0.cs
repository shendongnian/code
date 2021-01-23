    //Get Querystring name value collection  
        public static NameValueCollection GetQueryStringCollection(string url)  
        {  
            string keyValue = string.Empty;  
            NameValueCollection collection = new NameValueCollection();  
            string[] querystrings = url.Split('&');  
            if (querystrings != null && querystrings.Count() > 0)  
            {  
                for (int i = 0; i < querystrings.Count(); i++)  
                {  
                    string[] pair = querystrings[i].Split('=');  
                    collection.Add(pair[0].Trim('?'), pair[1]);  
                }  
            }  
            return collection;  
        }  
