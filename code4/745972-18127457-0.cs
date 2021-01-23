    public class MyFileClass
    {
        public MyFileClass(FileInfo info)
        {
            // do work
        }
        public MyFileClass(string url, string description)
            : this(GetFileInfo(url, description))
        { 
            // do more work
        }
        static FileInfo GetFileInfo(string url, string description)
        {
            return new FileInfo();
        }
    }
