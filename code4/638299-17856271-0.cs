    class AppConfigurationReader
        {
            public List<string> key1;
            public List<string> key2;
            public int ConnectionStringsFound;
    
            public int GetTotalConnectionStringsFound()
            {
                ConnectionStringsFound = key1.Count();
                return (ConnectionStringsFound);
            }
    
            public AppConfigurationReader()
            {
                key1= new List<string>();
                key12 = new List<string>();
    
                ConnectionStringsFound = 0;
            }
            public void getAppConfigconnectionStrings(string webConfigPath)
            {
                DataTable dtKeyValue = new DataTable();
    
                dtKeyValue.TableName = "app.config connectionString";
                dtKeyValue.Columns.Add("name");
                dtKeyValue.Columns.Add("connectionString");
    
                XmlTextReader reader = new XmlTextReader(webConfigPath);
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(reader);
                reader.Close();
    
                XmlElement root = xdoc.DocumentElement;
    
                XmlNodeList appSettings = xdoc.SelectNodes("/configuration/connectionStrings/add");
    
                foreach (XmlNode node in appSettings)
                {
                    DataRow row = dtKeyValue.NewRow();
                    String name = node.Attributes["name"].Value.ToString();
                    String connectionString = node.Attributes["connectionString"].Value.ToString();
    
                    //row["name"] = name;
                    //row["connectionString"] = connectionString;
                    //dtKeyValue.Rows.Add(row);
    
                    if (String.Equals(name, "Mykey1") == true)
                    {
                        key1.Add(connectionString);
                    }
                    else if (String.Equals(name, "Mykey2") == true)
                    {
                        key2.Add(connectionString);
                    }
                }
    
                //return dtKeyValue;
            }
    }
