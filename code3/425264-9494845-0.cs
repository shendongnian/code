    namespace FirstProject
    {
        public class ThisProjectSettings
        {
            public static string ConnectionString
            {
                get
                {
                    return Settings.Default.Conn;
                }
            }
        }
    }
