    #if DEBUG
        public static readonly string ConnectionString =
            string.Format(@"Data Source=..\..\Db\{0}; password='{1}'", DbFileName, DbPassword);
    #else
        public static readonly string ConnectionString =
			string.Format(@"Data Source=|DataDirectory|\Data\{0}; password='{1}'", DbFileName, DbPassword);
    #endif
