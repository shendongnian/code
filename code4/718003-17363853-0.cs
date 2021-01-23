    string text;
    string filename="k.txt";
        using (IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
        {
            if (isolatedStorage.FileExists(fileName))
            {
                StreamReader reader = new StreamReader(new IsolatedStorageFileStream(fileName, FileMode.Open, isolatedStorage));
                text = reader.ReadToEnd();
                reader.Close();
            }
            if(!String.IsNullOrEmpty(text))
            {
                 MessageBox.Show(text);
            }
        }
