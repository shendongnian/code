    try
    {
        using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
        {
            IsolatedStorageFileStream isoFileStream = myIsolatedStorage.OpenFile("test.xml", FileMode.Open); //you can use your filename just like above code
            using (StreamReader reader = new StreamReader(isoFileStream))
            {
                this.textbox1.Text = reader.ReadToEnd();
            }
        }
    }
    catch
    { }
