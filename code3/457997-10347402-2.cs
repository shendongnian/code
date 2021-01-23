     FileSystemWatcher watcher = new FileSystemWatcher();
     watcher.Path = dirPaths[i].ToString();
     watcher.NotifyFilter = NotifyFilters.Size;
     watcher.EnableRaisingEvents = true;
     watcher.Changed += delegate (object source, FileSystemEventArgs e)
     {
        float dirSize = CalculateFolderSize(watcher.Path); // using the path from the outer scope
        float limitSize = int.Parse(_config.TargetSize);//getting the limit size 
        if (dirSize > limitSize)
        {
            eventLogCheck.WriteEntry("the folloing path has crossed the limit " + directory);
            //TODO: mail sending
        }
     };
