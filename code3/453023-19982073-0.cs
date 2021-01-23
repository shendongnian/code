    public static async Task SerializeToFileEncrypt<T>(T o, StorageFile file)
            {
                DataContractSerializer dsc = new DataContractSerializer(typeof(T));
                MemoryStream memoryStream = new MemoryStream();
                dsc.WriteObject(memoryStream, o);
                memoryStream.Seek(0, SeekOrigin.Begin); // move to the beginning of the stream
                DataProtectionProvider provider = new DataProtectionProvider("Local=User");
                using (var raStream = await file.OpenAsync(FileAccessMode.ReadWrite))
                {
                    using (var filestream = raStream.GetOutputStreamAt(0))
                    {
                        await provider.ProtectStreamAsync(memoryStream.AsInputStream(), filestream);
                        await filestream.FlushAsync();
                    }
                }
            }
