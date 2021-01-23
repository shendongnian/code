    public static class ProgramData
    {
        private static string _path;
        public static string Path
        {
            get
            {
                if (!string.IsNullOrEmpty(_path)) { return _path; }
                // let's set it then
                _path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["programData"]))
                {
                    _path = ConfigurationManager.AppSettings["programData"];
                }
            }
        }
    }
