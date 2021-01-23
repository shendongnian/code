    string base64 = null;
    using (var iso = IsolatedStorageFile.GetUserStoreForApplication())
    using (var isf = iso.OpenFile(imageName, FileMode.Open, FileAccess.Read))
    using (var ms = new MemoryStream())
    {
        isf.CopyTo(ms);
        base64 = Convert.ToBase64String(ms.ToArray());
    }
