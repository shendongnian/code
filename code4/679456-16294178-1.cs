        class Program
        {
            static void Main(string[] args)
            {
                ZipLoad myZipLoad = new ZipLoad();
    
                string report;
                myZipLoad.TestUser = "userName";
                report = myZipLoad.Stat; //<- modified
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
    
    // ADDED
            public string Stat
            {
                get { return DOit_aka_Login(testUser, pWord); }
            }
    
            #endregion
    
            private string DOit_aka_Login(string uName, string pWord) //<- modified
            {
                // now you may need to check the input  if(uName =="" && pWord==""){...}
                //DOSTUFF.....
                return "Successfull";
            }
        }
