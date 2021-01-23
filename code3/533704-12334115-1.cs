    public static void InsertLarge( string path, string newText )
    {
        if(!File.Exists(path))
        {
            File.WriteAllText(path,newText);
            return;
        }
        var pathDir = Path.GetDirectoryName(path);
        var tempPath = Path.Combine(pathDir, Guid.NewGuid().ToString("N"));
        using (var stream = new FileStream(tempPath, FileMode.Create, 
            FileAccess.Write, FileShare.None, 4 * 1024 * 1024))
        {
            using (var sw = new StreamWriter(stream))
            {
                sw.WriteLine(newText);
                sw.Flush();
                using (var old = File.OpenRead(path)) old.CopyTo(sw.BaseStream);
            }
        }
        File.Delete(path);
        File.Move(tempPath,path);
    }
