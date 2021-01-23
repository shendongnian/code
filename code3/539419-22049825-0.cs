        public static string GetDBConnectionString()
        {
            string retValue = "";
            string domainUrl = "";
            string connectionKey = "";
            string dbConnectionString = "";
            domainUrl = GetDomainUrl();
            connectionKey = domainUrl.Substring(0, domainUrl.IndexOf(".")) + "DBConnectionString";
            dbConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionKey].ToString();
            retValue = dbConnectionString;
            return retValue;
        }
