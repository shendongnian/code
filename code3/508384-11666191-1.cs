    using Ionic.Zip;
    
    namespace ConsoleApplication23
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Zip your files like so
                ZipFile x = new ZipFile();
                x.AddFile(@"C:\myFile");
                x.AddFile(@"C:\mySecondFile");
                x.Save(@"c:\myZipFile.zip");
    
                //Unzip like so
                ZipFile y = ZipFile.Read(@"c:\myZipFile.zip");
    
                foreach (ZipEntry e in y)
                {
                    e.Extract(@"c:\test", ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }
    }
