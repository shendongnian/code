    public static class IniLoader
        {
            public static T Load<T>(string fileName)
            {
                T results = (T)Activator.CreateInstance(typeof(T));
    
                PropertyInfo[] tProperties = typeof(T).GetProperties();
                FieldInfo[] tFields = typeof(T).GetFields();
    
                var iniFile = Load(fileName);
    
                foreach (var property in tProperties)
                    if (iniFile.ContainsKey(property.Name))
                    {
                        object s = System.Convert.ChangeType(iniFile[property.Name].ToString(), property.PropertyType);
                        property.SetValue(results, s, null);
                    }
                foreach (var field in tFields)
                    if (iniFile.ContainsKey(field.Name))
                    {
                        object s = System.Convert.ChangeType(iniFile[field.Name].ToString(), field.FieldType);
                        field.SetValue(results, s);
                    }
    
                return results;
            }
    
            public static Dictionary<string, object> Load(string fileName)
            {
                Dictionary<string, object> results = new Dictionary<string, object>();
    
                string fileText = File.ReadAllText(fileName);
                string[] fileLines = fileText.Split('\r');
                if (fileLines.Length > 0)
                    for (int i = 0; i < fileLines.Length; i++)
                    {
                        string line = fileLines[i].Trim();
                        if (!string.IsNullOrEmpty(line))
                        {
                            int equalsLocation = line.IndexOf('=');
                            if (equalsLocation > 0)
                            {
                                string key = line.Substring(0, equalsLocation).Trim();
                                string value = line.Substring(equalsLocation + 1, line.Length - equalsLocation - 1);
    
                                results.Add(key, value);
                            }
                        }
                    }
    
                return results;
            }
        }
