            Uri uri = new Uri("http://www.picsimages.net/photo/lebron-james/lebron-james_1312647633.jpg");
            var fileName = Guid.NewGuid().ToString() + ".jpg";
            // download pic
            var bitmapImage = new BitmapImage();
            var httpClient = new HttpClient();
            var httpResponse = await httpClient.GetAsync(uri);
            byte[] b = await httpResponse.Content.ReadAsByteArrayAsync();
            // create a new in memory stream and datawriter
            using (var stream = new InMemoryRandomAccessStream())
            {
                using (DataWriter dw = new DataWriter(stream))
                {
                    // write the raw bytes and store
                    dw.WriteBytes(b);
                    await dw.StoreAsync();
                    // set the image source
                    stream.Seek(0);
                    bitmapImage.SetSource(stream);
                    // set image in first control
                    Image1.Source = bitmapImage;
                    // write to pictures library
                    var storageFile = await KnownFolders.PicturesLibrary.CreateFileAsync(
                        fileName, 
                        CreationCollisionOption.ReplaceExisting);
                    using (var storageStream = await storageFile.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        await RandomAccessStream.CopyAndCloseAsync(stream.GetInputStreamAt(0), storageStream.GetOutputStreamAt(0));
                    }
                }
            }
            // read from pictures library
            var pictureFile = await KnownFolders.PicturesLibrary.GetFileAsync(fileName);
            using ( var pictureStream = await pictureFile.OpenAsync(FileAccessMode.Read) )
            {
                bitmapImage.SetSource(pictureStream);
            }
            Image2.Source = bitmapImage;
        }
