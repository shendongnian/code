    public static BitmapImage LoadImageFromIsolatedStorage(string imgName)
            {
                try
                {
                    var bitmapImage = new BitmapImage();
                    //bitmapImage.CreateOptions = BitmapCreateOptions.DelayCreation;
                    using (var iso = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        //Check if file exists to prevent exception when trying to access the file.
                        if (!iso.FileExists(GetImageStorePathByFileName(imgName)))
                        {
                            return null;
                        }
                        //Since I store my picture under a folder structure, I wrote a method GetImageStorePathByFileName(string fileName) to get the correct path.
                        using (var stream = iso.OpenFile(GetImageStorePathByFileName(imgName), FileMode.Open, FileAccess.Read))
                        {
                            bitmapImage.SetSource(stream);
                        }
                    }
                    //Return the picture as a bitmapImage
                    return bitmapImage;
                }
                catch (Exception e)
                {
                    // handle the exception 
                    Debug.WriteLine(e.Message);
                }
    
                return null;
            }
