    public string GetConnectionStringByName(int DB_Number)
            {
                string returnValue = null;
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["Connection Name Here"];
                if (settings != null)
                    returnValue = settings.ConnectionString+Convert.ToString(DB_Number);
                return returnValue;
            }
