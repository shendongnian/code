     private void postFBWithImage()
        {
            try
            {
                using (IsolatedStorageFile myFile = IsolatedStorageFile.GetUserStoreForApplication())
                using (IsolatedStorageFileStream stream = myFile.OpenFile(AppSettings.ImageToShareKey, FileMode.Open, FileAccess.Read))
                {
                    byte[] byteArr = null;
                    using (var binRdr = new BinaryReader(stream))
                    using (var memStr = new MemoryStream())
                    {
                        const int ReadSize = 8196;
                        int chunkSize = 0;
                        do
                        {
                            byte[] buf = new byte[ReadSize];
                            chunkSize = binRdr.Read(buf, 0, ReadSize);
                            memStr.Write(buf, 0, ReadSize);
                        } while (chunkSize > 0);
                        byteArr = new byte[memStr.Length];
                        memStr.Position = 0;
                        memStr.Read(byteArr, 0, (int)memStr.Length);
                    }
                    var fb = new FacebookClient(AppSettings.FacebookPIN);
                    fb.PostCompleted += (o, args) =>
                    {
                        if (args.Error != null)
                        {
                            notPosted(args);
                            return;
                        }
                        Dispatcher.BeginInvoke(() =>
                        {
                            posted();
                        });
                    };
                    var parameters = new Dictionary<string, object>();
                    parameters["message"] = ShareComments;
                    parameters["file"] = new FacebookMediaObject
                        {
                            ContentType = "image/jpeg",
                            FileName = "image.jpeg",
                        }.SetValue(byteArr);
                    fb.PostAsync("me/photos", parameters);
                }
            }
            catch (Exception ex)
            {
                AppHelper.ErrorOccured(ex);
            }
        }
