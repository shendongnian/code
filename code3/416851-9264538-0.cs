    public void GetDirStructure(string path)
    {
        try
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            DirectoryInfo[] subDirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();
            foreach(FileInfo fi in files)
            {
                Console.WriteLine(fi.FullName.ToString());
            }
           
            if (subDirs != null)
            {
                foreach (DirectoryInfo sd in subDirs)
                {
                    GetDirStructure(path + @"\\" + sd.Name);
                }
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
    }
