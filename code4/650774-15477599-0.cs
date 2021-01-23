    void GetFiles()
        {
            DirectoryInfo d= new DirectoryInfo(strFolderPath);
           //file extension for pdf
            var files = d.GetFiles("*.pdf*");
            FileInfo[] subfileInfo = files.ToArray<FileInfo>();
            if (subfileInfo.Length > 0)
            {
                for (int j = 0; j < subfileInfo.Length; j++)
                {
                    bool isHidden = ((File.GetAttributes(subfileInfo[j].FullName) & FileAttributes.Hidden) == FileAttributes.Hidden);
                    if (!isHidden)
                    {
                        string strExtention = th.GetExtension(subfileInfo[j].FullName);
                        if (strExtention.Contains("pdf"))
                        {                            
                            string path = subfileInfo[j].FullName;
                            string name = bfileInfo[j].Name;                           
                        }
                    }
                }
            }
