    static void Main(string[] args)
    {
        using (FileStream fs = File.Open("fat.ima", FileMode.Open))
        {
            using (FatFileSystem floppy = new FatFileSystem(fs))
            {
                Dump(floppy.Root);
            }
        }
    }
    static void Dump(DiscDirectoryInfo di)
    {
        foreach (DiscDirectoryInfo subdi in di.GetDirectories())
        {
            Dump(subdi);
        }
        foreach (DiscFileInfo fi in di.GetFiles())
        {
            Console.WriteLine(fi.FullName);
            // get LFN name
            Console.WriteLine(" " + ((FatFileSystem)di.FileSystem).GetLongFileName(fi.FullName));
       
            // get LFN-ed full path
            Console.WriteLine(" " + ((FatFileSystem)di.FileSystem).GetLongFilePath(fi.FullName));
        }
    }
