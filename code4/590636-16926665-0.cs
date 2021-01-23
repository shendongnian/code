    IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
        var folder = ApplicationData.Current.LocalFolder;
        string folderfilename = folder.Path + "\\" + fileName;
        try
        {
            StreamWriter writeFile = new StreamWriter(new IsolatedStorageFileStream(folderfilename, FileMode.OpenOrCreate, myIsolatedStorage));
            writeFile.WriteAsync(content);
            writeFile.Close();
        }
        catch (Exception ex)
        {
        }
