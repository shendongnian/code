    public static T ResultItemToClass<T>(Dictionary<string, AttributeValue> resultItem) where T : new()
            {
                var resultDictionary = new Dictionary<string, object>();
    
                Type type = typeof(T);
                T ret = new T();
    
                foreach (KeyValuePair<string, AttributeValue> p in resultItem)
                    if (p.Value != null)
                        foreach (PropertyInfo prop in p.Value.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
                            if (prop.GetValue(p.Value, null) != null)                        
                                if ((string)prop.GetValue(p.Value, null) != "")
                                {
                                    if (prop.Name == "S")
                                        type.GetProperty(p.Key).SetValue(ret, prop.GetValue(p.Value, null), null);                                    
    
                                    if (prop.Name == "SS")
                                        type.GetProperty(p.Key).SetValue(ret, (List<string>)prop.GetValue(p.Value, null), null);
    
                                    if (prop.Name == "N")
                                        type.GetProperty(p.Key).SetValue(ret,  Convert.ToInt32(prop.GetValue(p.Value, null)), null);
    
                                    // TODO: add some other types. Too tired tonight
                                }                           
                return ret;
            }
