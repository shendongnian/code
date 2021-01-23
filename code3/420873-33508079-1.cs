    void DeleteFile(String FileToDelete)
    {
        fi = new System.IO.FileInfo(FileToDelete);
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
