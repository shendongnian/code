        public void SaveImageTo(string fileName = "SO.jpg")
        {
            string source = "http://i.stack.imgur.com/PIFN0.jpg";
            Uri url;
            if (Uri.TryCreate(source, UriKind.Absolute, out url))
            {
                WriteableBitmap wr;
                BitmapImage img = new BitmapImage(url);
                img.CreateOptions = BitmapCreateOptions.None;
                // When image is ready, show must go on.
                img.ImageOpened += (s, e) =>
                {
                    wr = new WriteableBitmap((BitmapImage)s);
                    //fileName += ".jpg"; // we dont need that
                    var myStore = IsolatedStorageFile.GetUserStoreForApplication();
                    if (myStore.FileExists(fileName))
                    {
                        // be gentle
                        MessageBoxResult result = MessageBox.Show("There is already a file called : \"" + fileName + "\"." + Environment.NewLine
                            + "We are going to override it. Continue ?", "Warning", MessageBoxButton.OKCancel);
                        if (result == MessageBoxResult.Cancel)
                            return;
                        myStore.DeleteFile(fileName);
                    }
                    IsolatedStorageFileStream myFileStream = myStore.CreateFile(fileName);
                    //WriteableBitmap wr = img; // image source already given
                    wr.SaveJpeg(myFileStream, wr.PixelWidth, wr.PixelHeight, 0, 85);
                    myFileStream.Close();
                    // Create a new stream from isolated storage, and save the JPEG file to the media library on Windows Phone.
                    myFileStream = myStore.OpenFile(fileName, FileMode.Open, FileAccess.Read);
                    MediaLibrary library = new MediaLibrary();
                    //byte[] buffer = ToByteArray(qrImage);
                    library.SavePicture(fileName, myFileStream);
                };
            }
        }
