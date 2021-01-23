        static void Main(string[] args)
        {
            getfiles get = new getfiles();
            List<string> files =  get.GetAllFiles(@"D:\Rishi");
            foreach(string f in files)
            {
                Console.WriteLine(f);
            }
            Console.Read();
        }
    }
    class getfiles
    {
        public List<string> GetAllFiles(string sDirt)
        {
            List<string> files = new List<string>();
            try
            {
                foreach (string file in Directory.GetFiles(sDirt))
                {
                    files.Add(file);
                }
                foreach (string fl in Directory.GetDirectories(sDirt))
                {
                    files.AddRange(GetAllFiles(fl));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return files;
        }
    }
