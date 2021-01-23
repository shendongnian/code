    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
    
            int cid = (int)value;
            People myC = App.ViewModel.getPerson(cid);
    
                string myImage = myC.Image;
                object result = myC.TileColor;
    
                if (myImage != null)
                {
    
                    BitmapImage bi = new BitmapImage();
                    bi.CreateOptions = BitmapCreateOptions.BackgroundCreation;
                    ImageBrush imageBrush = new ImageBrush();
    
                    using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        if (myIsolatedStorage.FileExists(myImage))
                        {
    
                            using (
                                IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(myImage, FileMode.Open,
                                                                                                  FileAccess.Read))
                            {
                                bi.SetSource(fileStream);
                                imageBrush.ImageSource = bi;
                            }
                        }
                        else
                        {
                            return result;
                        }
                    }
    
                    return imageBrush;
                }
                else
                {
                    return result;
                }
    
        }
