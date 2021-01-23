    public static class RoamingStorage<T> {
        public static async void SaveData(string filename, T data)
        {
            try
            {
                StorageFile file = await ApplicationData.Current.RoamingFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
                using (IRandomAccessStream raStream = await file.OpenAsync(FileAccessMode.ReadWrite))
                {
                    using (IOutputStream outStream = raStream.GetOutputStreamAt(0))
                    {
                        DataContractSerializer serializer = new DataContractSerializer(typeof(List<Item>));
                        serializer.WriteObject(outStream.AsStreamForWrite(), data);
                        await outStream.FlushAsync();
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        public static async System.Threading.Tasks.Task<T> LoadData(string filename)
        {
            T data = default(T);
            try
            {
                StorageFile file = await ApplicationData.Current.RoamingFolder.GetFileAsync(filename);
                using (IInputStream inStream = await file.OpenSequentialReadAsync())
                {
                   DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                   data = (T)serializer.ReadObject(inStream.AsStreamForRead());
                }
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }
    }
