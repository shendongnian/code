    filename = "Myicon.png";
    
    IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
    if (!store.FileExists(filename))
    {
        using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(filename, FileMode.Create, FileAccess.Write, store))
            stream.Write(imgBytes, 0, imgBytes.Length);
    }
    
    //get Product ID from manifest. Add using System.Linq; if you haven't already
    Guid productId = new Guid((from manifest in System.Xml.Linq.XElement.Load("WMAppManifest.xml").Descendants("App") select manifest).SingleOrDefault().Attribute("ProductID").Value);
    string storeFile = "C:/Data/Users/DefApps/AppData/" + productId.ToString("B") + "/Local/" + filename;
    this.Items.Add(new MyViewModel() { Icon = storeFile });
