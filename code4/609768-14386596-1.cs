        public async Task<T> LoadLocalXMLAsync<T>(string filename)
        {
            try
            {
                StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
                T o = default(T);
                using (IInputStream inStream = await file.OpenSequentialReadAsync())
                {
                    var serializer = new DataContractSerializer(typeof(T));
                    o = (T)serializer.ReadObject(inStream.AsStreamForRead());
                }
                return o;
            }
            catch (Exception ex)
            {
                return default(T);
                // ERROR HANDLING AND LOGGING
            }
        }
        public async Task SaveLocalXMLAsync(string filename, object o)
        {
            try
            {
                var serializer = new DataContractSerializer(o.GetType());
                StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
                using (Stream fileStream = await file.OpenStreamForWriteAsync())
                {
                    serializer.WriteObject(fileStream, o);
                    await fileStream.FlushAsync();
                }
            }
            catch (Exception ex)
            {
                // ERROR HANDLING AND LOGGING
            }
        }
    }
