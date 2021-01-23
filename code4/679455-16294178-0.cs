    class Program
    {
        static void Main(string[] args)
        {
            ZipLoad myZipLoad = new ZipLoad();
            string report;
            myZipLoad.TestUser = "userName";
            report = myZipLoad.DOit_aka_Login();
        }
    }
    class ZipLoad
    {
        #region private Values
        private string testUser;
        private string pWord;
        #endregion
        #region Properties
        public string TestUser
        {
            get { return testUser; }
            set { testUser = value; }
        }
        public string PWord
        {
            private get { return pWord; }
            set { pWord = value; }
        }
        #endregion
        public string DOit_aka_Login() //string uName, string pWord
        {
            //DOSTUFF.....
            // here you cann use 
            // TestUser aka uName 
            // and
            // PWord aka pWord
            return "Successfull";
        }
    }
