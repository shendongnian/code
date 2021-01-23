    class Program
    {
        private static int? _fileControlNo;
        static void Main(string[] args)
        {
            string[] sArrElements = new string[] { "1", "2", "3", null };
            int result;
            if (int.TryParse(sArrElements[3], out result))
            {
                FileControlNo = result;
            }
            if (_fileControlNo.HasValue)
            {
                // do something here
            }
        }
        public static int? FileControlNo
        {
            get { return _fileControlNo; }
            set { _fileControlNo = value; }
        } 
    }
