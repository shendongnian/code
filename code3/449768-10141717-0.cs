        public class MyTest
        {
            string DirectoryPath = "";
            public void Test()
            {
                DirectoryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.InternetCache);
            }
            public void UseString()
            {
                //Use DirectoryPath
            }
        }
