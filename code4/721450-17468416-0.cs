    using( FileStream fs = File.OpenRead(path))
    {
        if(path.Contains(".rar"))
        {
            try
            {
               //RarArchive.WriteToDirectory(fs.Name, Path.Combine(@"D:\DataDownloadCenter", path2), ExtractOptions.Overwrite);
            }
            catch { }
         }
    }
