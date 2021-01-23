        internal static async Task<bool> SaveSetting(string Key, Object value)
        {
            var ms = new MemoryStream();
            DataContractSerializer serializer = new DataContractSerializer(value.GetType());
            serializer.WriteObject(ms, value);
            await ms.FlushAsync();
            // Uncomment this to preview the contents being written
            //char[] buffer = new char[ms.Length];
            //ms.Seek(0, SeekOrigin.Begin);
            //var sr = new StreamReader(ms);
            //sr.Read(buffer, 0, (int)ms.Length);
            ms.Seek(0, SeekOrigin.Begin);
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(Key, CreationCollisionOption.ReplaceExisting);
            using (Stream fileStream = await file.OpenStreamForWriteAsync())
            {
                await ms.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
            }
            return true;
        }
        // Necessary to pass back both the result and status from an async function since you  can't pass by ref
        internal class ReadResults
        {
            public bool Success { get; set; }
            public Object Result { get; set; }
        }
        internal async static Task<ReadResults> ReadSetting<type>(string Key, Type t)
        {
            var rr = new ReadResults();
            try
            {
                var ms = new MemoryStream();
                DataContractSerializer serializer = new DataContractSerializer(t);
                StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync(Key);
                using (IInputStream inStream = await file.OpenSequentialReadAsync())
                {
                    rr.Result = (type)serializer.ReadObject(inStream.AsStreamForRead());
                }
                rr.Success = true;  
            }
            catch (FileNotFoundException)
            {
                rr.Success = false;
            }
            return rr;
        }
