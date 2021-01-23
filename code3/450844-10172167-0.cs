    public staticList<FileInfo> GetFiles(string folder, string includeMask, string     excludeMask, SortOrder sortOrder, SearchOption searchOption)
    {
    DirectoryInfo folderDirectoryInfo = newDirectoryInfo(folder);
    List<FileInfo> files = newList<FileInfo>(folderDirectoryInfo.GetFiles(includeMask,  searchOption));
    
    stringexcludeMaskRegEx = FileSystemHelper.WildcardToRegex(excludeMask);
    // exclude files
    files = (fromfile infiles
             where!Regex.IsMatch(file.Name, excludeMaskRegEx) 
             selectfile).ToList<FileInfo>();
    if(files.Count > 0)
    {
        switch(sortOrder)
        {
            //somecode
        }
      }
      returnfiles;
      }
