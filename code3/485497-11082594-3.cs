    class WriteToFile
    {
        public WriteToFile(string newFileName)
        {
            _newFileName = newFileName;
        }
        private string _newFileName;
        public void WriteInFile(string MyFolderName, string MytextBox, string MytbR, string MycbTest)
        {
            CButtonCreate myFile = new CButtonCreate();
            StreamWriter sw = new StreamWriter(_newFileName);
        }
    }
