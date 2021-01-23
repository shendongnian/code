    BitmapImage bi = new BitmapImage();
     
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile("logo.jpg", FileMode.Open, FileAccess.Read))
                    {
                        bi.SetSource(fileStream);
                        this.img.Height = bi.PixelHeight;
                        this.img.Width = bi.PixelWidth;
                    }
                }
                this.img.Source = bi;
