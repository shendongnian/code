    /*If your solution is web application, make sure Database1.sdf location path is under the 
         * App_Data folder 
         * Web.Config <add name="LocalDB" connectionString="Data Source=|DataDirectory|\Database1.sdf"/>
         */
        protected string ConnString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["LocalDB"].ToString();
            }
        }
        /*
         * or you can use try absolute path as connectionstring
         * modify your directory path as PhysicalApplicationPath result
         */
        public string BaseDirConnString
        {
            get
            {
                if ((HttpContext.Current == null) || (HttpContext.Current.Request == null))
                {
                    throw new ApplicationException("...");
                }
                return @"Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "VIN Decoder\\Database1.sdf";
            }
        }
        protected SqlCeConnection SqlCeConnection
        {
            get
            {
                var connection = new SqlCeConnection(BaseDirConnString);
                connection.Open();
                return connection;
            }
        }
