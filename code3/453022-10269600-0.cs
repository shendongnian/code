    public static async Task SerializeToFileEncrypt<T>(T o, StorageFile file)
    {
            DataContractSerializer dsc = new DataContractSerializer(typeof(T));                
            MemoryStream memoryStream = new MemoryStream();
            dsc.WriteObject(memoryStream, o);
            memoryStream.Seek(0, SeekOrigin.Begin); // move to the beginning of the stream
            DataProtectionProvider provider = new DataProtectionProvider("Local=User");
            var raStream = await file.OpenAsync(FileAccessMode.ReadWrite);
            using(var filestream = raStream.GetOutputStreamAt(0))
            {
                await provider.ProtectStreamAsync(memoryStream.AsInputStream(), filestream);
                await filestream.FlushAsync();                        
            }
    }
    public static async Task<T> DeserializeFromFileDecrypt<T>(StorageFile file)
    {
        DataContractSerializer dsc = new DataContractSerializer(typeof(T));
        MemoryStream memoryStream = new MemoryStream();
        DataProtectionProvider provider = new DataProtectionProvider();
        await provider.UnprotectStreamAsync((await file.OpenStreamForReadAsync()).AsInputStream(), memoryStream.AsOutputStream());
        memoryStream.Seek(0, SeekOrigin.Begin); // move to the beginning of the stream
        return (T) dsc.ReadObject(memoryStream);
    }
