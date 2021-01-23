    XDocument doc = XDocument.Load( "c://web.config" );
           var elements = doc.Descendants( "AppSettings" );
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
                for (int i = 0; i < elements.Count; i++)
                {
                   string key = elements[i].Attributes["key"].Value.ToString();
                   string value = elements[i].Attributes["value"].Value.ToString();
                   keyvalues.Add(key,value);
                }  
