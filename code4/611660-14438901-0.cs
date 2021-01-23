        public T Deserialize<T>(string filePath)
        {
            Stream stream = null;
            try
            {
                FileStream readFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                XmlSerializer serializerObj = new XmlSerializer(typeof(T));
                return (T)serializerObj.Deserialize(readFileStream);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }
