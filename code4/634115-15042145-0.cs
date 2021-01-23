            var file = await folder.CreateFileAsync(fileName, options);
            using (var fs = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite))
            {
                using (var outStream = fs.GetOutputStreamAt(0))
                {
                    using (var dataWriter = new Windows.Storage.Streams.DataWriter(outStream))
                    {
                        dataWriter.WriteBytes(bytes);
                        await dataWriter.StoreAsync();
                        dataWriter.DetachStream();
                        await outStream.FlushAsync();
                    }
                }
            }
