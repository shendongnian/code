    IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
    IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile("ItemFile.txt", FileMode.Open, FileAccess.Read);
    using (StreamReader reader = new StreamReader(fileStream))
    {    //Visualize the text data in a TextBlock text
        while ((line = reader .ReadLine()) != null)
        {
             imageCollection.Add(new Image());
             imageCollection[counter].Source = new BitmapImage(new Uri("Images/" + line + ".png", UriKind.Relative));
        }
    }
    
