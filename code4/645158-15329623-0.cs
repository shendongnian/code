    List<string> values = new List<string>()
    foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key.StartsWith("Service1URL"))
                {
                    string value = ConfigurationManager.AppSettings[key];
                    values.Add(value);
                }
                
            }
    
    string[] repositoryUrls = values.ToArray();
