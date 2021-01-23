     class MyFile
        {
            public string FullPath { get; set; }
            public string Extension
            {
                get
                {
                    return Path.GetExtension(FullPath);
                }
            }
            public string PathRoot
            {
                get
                {
                    return Path.GetPathRoot(FullPath);
                }
            }
            public DateTime CreationTime
            {
                get
                {
                    return File.GetCreationTime(FullPath);
                }
            }
        }
