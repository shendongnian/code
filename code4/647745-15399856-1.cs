    using (var isf = IsolatedStorageFile.GetUserStoreForApplication())
    {
         using (var fs = isf.CreateFile(path + "\\" + filename + ".jpg"))
         {
             SaveCapturedImageFromClipBoard(fs);
         }
    }
