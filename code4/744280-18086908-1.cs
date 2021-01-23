    public static class AppSettings
    {
        private static int _commandTimeout = -1;
        public static int CommandTimeout
        {
            get
            {
                if (_commandTimeout != -1) { return _commandTimeout; }
                var configTimeout = ConfigurationManager.AppSettings["commandTimeout"];
                if (!string.IsNullOrEmpty(configTimeout))
                {
                    _commandTimeout = Convert.ToInt32(configTimeout);
                }
                else
                {
                    _commandTimeout = 1; // this is the default if the setting doesn't exist
                }
                return _commandTimeout;
            }
        }
    }
