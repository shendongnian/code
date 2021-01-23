    var response = await HttpWebRequest.Create(url).GetResponseAsync();
                    List<Byte> allBytes = new List<byte>();
                    using (Stream imageStream = response.GetResponseStream())
                    {
                        byte[] buffer = new byte[4000];
                        int bytesRead = 0;
                        while ((bytesRead = await imageStream.ReadAsync(buffer, 0, 4000)) > 0)
                        {
                            allBytes.AddRange(buffer.Take(bytesRead));
                        }
                    }
                    StorageFolder storageFolder = awai KnownFolders.PicturesLibrary.CreateFolderAsync("QR Codes Generator",CreationCollisionOption.OpenIfExists );
                    //var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(
                    //            System.IO.Path.GetRandomFileName()+".png", CreationCollisionOption.FailIfExists);
                    // var folder = await StorageFolder.GetFolderFromPathAsync("");
                    var file = await storageFolder.CreateFileAsync(
                    System.IO.Path.GetRandomFileName() + ".png", CreationCollisionOption.FailIfExists);
                    await FileIO.WriteBytesAsync(file, allBytes.ToArray());
                MessageDialog a = new MessageDialog("QR Code saved successfully!","QR Codes Generator");
                    a.ShowAsync();
