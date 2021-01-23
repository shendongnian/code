    /// <summary>
    /// Serializes a file to a compressed XML file. If an error occurs, the exception is NOT caught.
    /// </summary>
    /// <typeparam name="T">The Type</typeparam>
    /// <param name="obj">The object.</param>
    /// <param name="fileName">Name of the file.</param>
    public static void SerializeToXML<T>(T obj, string fileName)
    {
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                using (GZipStream compressor = new GZipStream(fs, CompressionMode.Compress))
                {
                    serializer.Serialize(compressor, obj);
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    /// <summary>
    /// Deserializes an object from XML.
    /// </summary>
    /// <typeparam name="T">The object</typeparam>
    /// <param name="file">The file.</param>
    /// <returns>
    /// The deserialized object
    /// </returns>
    public static T DeserializeFromXml<T>(string file)
    {
        T result;
        XmlSerializer ser = new XmlSerializer(typeof(T));
        using (FileStream fs = new FileStream(file, FileMode.Open))
        {
            using (GZipStream decompressor = new GZipStream(fs, CompressionMode.Decompress))
            {
                result = (T)ser.Deserialize(decompressor);
                return result;
            }
        }
    }
}
    Usage:
    SerializeToXML(controlList , yourPath);
      this.controlList = DeserializeFromXml<List<ConsoleStrategyItem>>(yourPath);
