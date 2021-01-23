    public Dictionary<string, string> readConfig(string sectionName, bool soapService=false, Dictionary<string, string> config=null)
    {
        Dictionary<string, string> myConfig = config ?? new Dictionary<string, string>();
        try
        {
            XmlDocument configXml = new XmlDocument();
            string configPath = "config.xml";
            if (soapService)
            {
                string applicationPath = HttpContext.Current.Server.MapPath(null);
                configPath = Path.Combine(applicationPath, "config.xml");
            }
            configXml.Load(configPath);
     
            XmlNodeList options = configXml.SelectNodes(string.Format("/options/{0}", sectionName));
            foreach (XmlNode option in options)
            {
                XmlNodeList settings = option.SelectNodes("./item[@key and @value]");
                foreach (XmlNode setting in settings)
                {
                    myConfig.Add(setting.Attributes["key"].Value, setting.Attributes["value"].Value);
                }
            }
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine("Config KeyNotFoundException: {0}", ex.Message);
        }
        catch (XmlException ex)
        {
            Console.WriteLine("Config XmlException: {0}", ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Config Exception: {0}", ex.Message);
            Console.WriteLine("StackTrace: {0}", ex.StackTrace);
        }
        return myConfig;
    }
