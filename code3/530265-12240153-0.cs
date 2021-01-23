    public void RemoveLastFile(string folderPath, long dirSizeLimit)
    {
        long size = 0;
        var files = new DirectoryInfo(folderPath).GetFiles();
        files.Sum(f => size += f.Length);
        if(size > dirSizeLimit)
        {
           var sorted = files.OrderBy(f => f.LastWriteTime);
           File.Delete(sorted.First().FullName);
       }
    }
