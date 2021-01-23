    public class SqlInstance
    {
        private SqlInstance() {}
        internal static SqlInstance GetInstance(DataManager.Token friendshipToken, string key)
        {
            if (friendshipToken == null)
                throw new ArgumentNullException("friendshipToken");
            return new SqlInstance();
        }
    }
    public class FileInstance
    {
        private FileInstance() {}
        internal static FileInstance GetInstance(DataManager.Token friendshipToken, string key)
        {
            if (friendshipToken == null)
                throw new ArgumentNullException("friendshipToken");
            return new FileInstance();
        }
    }
    public class DataManager
    {
        private static Token token;
        static DataManager()
        {
            Token.SetToken();
        }
        public class Token
        {
            private Token() {}
            public static void SetToken()
            {
                token = new Token();
            }
        }
        public SqlInstance GetSqlChannelInstance()
        {
            return SqlInstance.GetInstance(token, "dev.1");
        }
        public FileInstance GetFileInstance()
        {
            return FileInstance.GetInstance(token, "fil.1");
        }
    }
