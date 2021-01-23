                  List<string> keys = new List<string>();
        
                    // retrieve application Cache enumerator
          IDictionaryEnumerator enumerator = System.Web.HttpRuntime.Cache.GetEnumerator();
        
                    // copy all keys that currently exist in Cache
                    while (enumerator.MoveNext())
                    {
                        keys.Add(enumerator.Key.ToString());
                    }
        
                    // delete every key from cache
                    for (int i = 0; i < keys.Count; i++)
                    {
                        HttpRuntime.Cache.Remove(keys[i]);
                    }
