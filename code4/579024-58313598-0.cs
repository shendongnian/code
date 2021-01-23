    public static List<string> GetFilesEveryFolder(string folder, string mask, SearchOption searchOption, bool _trimA1 = false)
    {
        List<string> list = new List<string>(); ;
        List<string> dirs = null;
        try
        {
            dirs = GetFoldersEveryFolder(folder, "*").ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("GetFiles with path: " + folder, ex);
        }
        foreach (var item in dirs)
        {
            try
            {
                list.AddRange(Directory.GetFiles(item, mask, SearchOption.TopDirectoryOnly));
            }
            catch (Exception ex)
            {
                // Not throw exception, it's probably Access denied on Documents and Settings etc
                //ThrowExceptions.FileSystemException(type, RH.CallingMethod(), ex);
            }
        }
        CA.ChangeContent(list, d => SH.FirstCharLower(d));
        if (_trimA1)
        {
            list = CA.ChangeContent(list, d => d = d.Replace(folder, ""));
        }
        return list;
    }
