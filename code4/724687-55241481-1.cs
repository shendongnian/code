        public string[] GetFiles()
        {
            if (!Directory.Exists(@"your\path"))
            {
                Directory.CreateDirectory(@"your\path");
            }
            DirectoryInfo dirInfo = new DirectoryInfo(@"your\path");
            FileInfo[] fileInfos = dirInfo.GetFiles();
            ArrayList list = new ArrayList();
            foreach (FileInfo info in fileInfos)
            {
                if(info.Name != file)
                {
                    // HACK: Just skip the protected samples file...
                    if (info.Name.IndexOf("protected") == -1)
                        list.Add(info.FullName);
                }
            }
            return (string[])list.ToArray(typeof(string));
        }
