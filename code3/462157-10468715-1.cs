    private void _Search(string path, string name)
        {
            if (stopSearch) Thread.CurrentThread.Abort();
            DirectoryInfo Roots = new DirectoryInfo(path);
            foreach (FileInfo file in Roots.GetFiles())
            {
                if (stopSearch) Thread.CurrentThread.Abort(); 
                if (file.Name.IndexOf(name, StringComparison.InvariantCultureIgnoreCase) > -1)
                {
                    _File item = new _File();
                    item.Name = file.Name;
                    item.Size = file.Length;
                    item.Path = file.FullName;
                    callback.File(item);
                }
            }
            foreach (DirectoryInfo folder in Roots.GetDirectories())
            {
                if (stopSearch) Thread.CurrentThread.Abort();
                if (folder.Name.IndexOf(name, StringComparison.InvariantCultureIgnoreCase) > -1)
                {
                    _Folder item = new _Folder();
                    item.Name = folder.Name;
                    item.Path = folder.FullName;
                    callback.Folder(item);
                }
                _Search(folder.FullName, name);
            }
        }
