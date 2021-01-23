    public static class FileData
    {
        private static readonly string s_sFileData;
        static FileData ()
        {
            s_sFileData = ...; // read file data here using your code
        }
        public static string Contents
        {
            get
            {
                return ( string.Copy ( s_sFileData ) );
            }
        }
    }
