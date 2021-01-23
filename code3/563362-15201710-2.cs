    MessageBar.Text = "Uploading to SkyDrive";
    IsolatedStorageFileStream fileStream = null;
    //string strSaveName = "images.jpg";               
    try
    {
       using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
       {
          fileStream = store.OpenFile("contact.txt", FileMode.Open, FileAccess.Read);
       }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
    client.UploadAsync("me/SkyDrive", "contact.txt", fileStream, OverwriteOption.Overwrite);
