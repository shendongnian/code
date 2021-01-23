    #if DEBUG
        public static readonly string ConnectionString =
            string.Format(@"Data Source=..\..\DbTest\{0}; password='{1}'", DbFileName, DbPassword);
    #else
        public static readonly string ConnectionString =
			string.Format(@"Data Source=|DataDirectory|\{0}; password='{1}'", DbFileName, DbPassword);
    #endif
