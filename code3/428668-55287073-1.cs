    private static string LoadConnectionString(string id = "LiteDB")
        {
            try { 
                return ConfigurationManager.ConnectionStrings[id].ConnectionString + ";password=your_pass";
            }
            catch (Exception loadConnectionStringError)
            {
                Console.WriteLine("loadConnectionStringError: " + loadConnectionStringError.ToString());
                return null;
            }
        }
