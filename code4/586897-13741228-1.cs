        /// <summary>
    /// Serialization helper
    /// </summary>
    public static class XmlSerializationHelper
    {
        /// <summary>
        /// Deserializes an instance of T from the stringXml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlContents"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static T Deserialize<T>(string xmlContents)
        {            
            // Create a serializer
            using (StringReader s = new StringReader(xmlContents))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(s);
            }
        }
        /// <summary>
        /// Serializes the object of type T to the filePath
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"></param>
        /// <param name="filePath"></param>
        public static void Serialize<T>(T serializableObject, string filePath)
        {
            Serialize(serializableObject, filePath, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"></param>
        /// <param name="filePath"></param>
        /// <param name="encoding"></param>
        public static void Serialize<T>(T serializableObject, string filePath, Encoding encoding)
        {
            // Create a new file stream
            using (FileStream fs = File.OpenWrite(filePath))
            {
                // Truncate the stream in case it was an existing file
                fs.SetLength(0);
                TextWriter writer; 
                // Create a new writer
                if (encoding != null)
                {
                    writer = new StreamWriter(fs, encoding);
                }
                else
                {
                    writer = new StreamWriter(fs);
                }   
                // Serialize the object to the writer
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, serializableObject);
                // Create writer
                writer.Close();
            }
        }
    }
