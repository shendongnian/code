    class File
    {
        public string FileInfo = "";
        public override string ToString()
        {
            return FileInfo;
        }
        public virtual File GetRaw()
        {
            return this;
        }
    }
    class ZippedFile : File
    {
        public File Unzip()
        {
            // Do actual unzip here..
            return new File { FileInfo = FileInfo.Substring(0,8) };
        }
        public override File GetRaw()
        {
            return Unzip();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<object> files = new List<object>();
            files.Add(new File { FileInfo = "BeepBoop" });
            files.Add(new ZippedFile { FileInfo = "BeepBoopfQAWEFRLQER:LKAR:LWEasdfw;lekfrqW:ELR" });
            files.Add(new File { FileInfo = "BoopBeep" });
            files.Add(new ZippedFile { FileInfo = "BoopBeepAWSLF:KQWE:LRKsdf;lKWEFL:KQwefkla;sdfkqwe" });
            foreach(var f in files)
            {
                File rawFile = ((File)f).GetRaw();
                Console.WriteLine(rawFile);
            }
            Console.ReadKey();
        }
    }
