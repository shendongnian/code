        /// <summary>
        /// Deserializes xml file to object
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static object DeSerializeFromXML(string filePath, Type type)
        {
            object data = null;
            System.IO.Stream stream = null;
            try
            {
                stream = System.IO.File.Open(filePath, System.IO.FileMode.Open);
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(type);
                data = x.Deserialize(new System.Xml.XmlTextReader(stream));
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
            return data;
        }
