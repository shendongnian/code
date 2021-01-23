    private static void OnChanged(object sender, FileSystemEventArgs e)
    {
        BuildingestionXml(string.Format(@"{0}\{1}",e.FullPath,e.Name));
        Console.WriteLine(@"Second: Success sending{0}\{1}", e.FullPath, e.Name);
        ((FileSystemWatcher)sender).Dispose();
    }
