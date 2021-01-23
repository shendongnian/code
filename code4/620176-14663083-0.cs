    static void DirSearch(string sDir, FtpConnection ftp, string currentDirectory)
    {
        try
        {
            ftp.SetCurrentDirectory(currentDirectory);
            foreach (string f in Directory.GetFiles(sDir))
            {
                Uri uri = new Uri(f);
                ftp.PutFile(f, System.IO.Path.GetFileName(uri.LocalPath));
            }
            foreach (string d in Directory.GetDirectories(sDir))
            {
                ftp.SetCurrentDirectory(currentDirectory);
                string dirname = new DirectoryInfo(d).Name;
                if (!ftp.DirectoryExists(dirname))
                {
                    ftp.CreateDirectory(dirname);
                }
               
                string newCurrentDir = currentDirectory + "/" + dirname ;
                DirSearch(d, ftp, newCurrentDir);
            }
        }
        catch (System.Exception e)
        {
            MessageBox.Show(String.Format("Błąd FTP: {0} {1}", e.Message), "Błąd wysyłania plików na FTP", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
