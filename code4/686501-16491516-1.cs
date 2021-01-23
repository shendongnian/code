    void DoCopy(string path)
    {
        var copytask = new Task(() =>
        {
            string destinoComNomeArquivo = @"C:\" + Path.GetFileName(path);
            DirectoryCopy(path, destinoComNomeArquivo, false);
        });
        copytask.Start();
    }
    private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);
        DirectoryInfo[] dirs = dir.GetDirectories();
        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException(
                "Source directory does not exist or could not be found: "
                + sourceDirName);
        }
        if (!Directory.Exists(destDirName))
        {
            Directory.CreateDirectory(destDirName);
        }
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            string temppath = Path.Combine(destDirName, file.Name);
            file.CopyTo(temppath, false);                
        }
        var counter = 0;
        var maxcounter = files.Count();
        while (maxcounter < counter)
        {
            var item = files.ElementAt(counter).Name;
            WriteAsnc(item);
        }
        if (copySubDirs)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath, copySubDirs);
            }
        }
    }
    const int _maxwritingprocess = Environment.ProcessorCount;
    int _currentwritingtasks;
    void WriteAsnc(string filepath)
    {
        _currentwritingtasks++;
        var task = Task.Factory.StartNew(() => 
        {
            XDocument doc = XDocument.Load(filepath);
            doc.Elements().First().Add(new XAttribute("Attribute Name","Attribute Value"));
            doc.Save(filepath);
            _currentwritingtasks--;
        });
        if(_currentwritingtasks == _maxwritingprocess)
            task.Wait();
        _currentwritingtasks--;
    }
