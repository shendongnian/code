    private static string[] ReadSettings(string settingsFile)
        {
            string[] a = new string[2];
            try
            {
                XmlTextReader xmlReader = new XmlTextReader(settingsFile);
                while (xmlReader.Read())
                {
                    switch (xmlReader.Name)
                    {
                        case "system":
                            break;
                        case "login":
                            a[0] = xmlReader.ReadString();
                            break;
                        case "password":
                            a[1] = xmlReader.ReadString();
                            break;
                    }
                }    
                return a;
            }
            catch (Exception ex)
            {
                return a;
            }
        }
