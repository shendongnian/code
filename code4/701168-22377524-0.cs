            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile imageFile = await folder.CreateFileAsync("Sample.png", CreationCollisionOption.ReplaceExisting);
            using (IRandomAccessStream fileStream = await imageFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                using (IOutputStream outputStream = fileStream.GetOutputStreamAt(0))
                {
                    using (DataWriter dataWriter = new DataWriter(outputStream))
                    {
                        dataWriter.WriteBytes(imageBuffer);
                        await dataWriter.StoreAsync();
                        dataWriter.DetachStream();
                        
                    }
                    //await outputStream.FlushAsync();
                }
                //await fileStream.FlushAsync();
            }
