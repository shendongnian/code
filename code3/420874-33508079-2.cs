    public static void DeleteFile(String fileToDelete)
    {
        var fi = new System.IO.FileInfo(fileToDelete);
        if (fi.Exists)
        {
            fi.Delete();
            fi.Refresh();
            while (fi.Exists)
            {    System.Threading.Thread.Sleep(100);
                 fi.Refresh();
            }
        }
    }
