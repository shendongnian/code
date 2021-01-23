     private async Task<T> ReadXml<T>(StorageFile xmldata)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(List<myclass>));
            T data;
            using (var strm = await xmldata.OpenStreamForReadAsync())
            {
                TextReader Reader = new StreamReader(strm);
                data = (T)xmlser.Deserialize(Reader);
            }
            return data;
        }
        private async Task writeXml<T>(T Data, StorageFile file)
        {
            try
            {
                StringWriter sw = new StringWriter();
                XmlSerializer xmlser = new XmlSerializer(typeof(T));
                xmlser.Serialize(sw, Data);
 
                using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
                {
                    using (IOutputStream outputStream = fileStream.GetOutputStreamAt(0))
                    {
                        using (DataWriter dataWriter = new DataWriter(outputStream))
                        {
                            dataWriter.WriteString(sw.ToString());
                            await dataWriter.StoreAsync();
                            dataWriter.DetachStream();
                        }
                        await outputStream.FlushAsync();
                    }
                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message.ToString());
            }
        }
