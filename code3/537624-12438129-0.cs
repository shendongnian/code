        /// <summary>
        /// Serializes object to file
        /// </summary>
        /// <param name="data"></param>
        /// <param name="FilePath"></param>
        public static void SerializeMyObject(object data, string FilePath)
        {
            System.IO.Stream stream = null;
            try
            {
                stream = System.IO.File.Open(FilePath, System.IO.FileMode.Create);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bformatter =
                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bformatter.Serialize(stream, data);
                stream.Close();
                stream.Dispose();
            }
            catch (Exception ex)
            {
                try
                {
                    stream.Close();
                    stream.Dispose();
                }
                catch (Exception)
                {
                }
                throw new Exception(ex.Message);
            }
        }
