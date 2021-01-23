     public string GetConnectionStringByName()
            {
                string returnValue = null;
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["Connection Name Here"];
                if (settings != null)
                    returnValue = settings.ConnectionString;
                return returnValue;
            }
