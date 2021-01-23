     public static List<string> GetPropertyValues(this SearchResult searchResult,string property)
            {
                var prop = searchResult.Properties[property];
                var results = new List<string>();
    
    
                if (prop != null && prop.Count > 0)
                {
                    for (int i = 0; i < prop.Count - 1; i++)
                    {
                        results.Add(prop[i].ToString());
                    }
                }
                return results;
            }
