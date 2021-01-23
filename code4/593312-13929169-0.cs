    /// <summary>
    /// XML serializer helper class. Serializes and deserializes objects from/to XML
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize/deserialize.
    /// Must have a parameterless constructor and implement <see cref="Serializable"/></typeparam>
    public class XmlSerializer<T> where T: class, new()
    {
        /// <summary>
        /// Deserializes a XML file.
        /// </summary>
        /// <param name="filename">The filename of the XML file to deserialize</param>
        /// <returns>An object of type <c>T</c></returns>
        public static T DeserializeFromFile(string filename)
        {
            return DeserializeFromFile(filename, new XmlReaderSettings());
        }
        /// <summary>
        /// Deserializes a XML file.
        /// </summary>
        /// <param name="filename">The filename of the XML file to deserialize</param>
        /// <param name="settings">XML serialization settings. <see cref="System.Xml.XmlReaderSettings"/></param>
        /// <returns>An object of type <c>T</c></returns>
        public static T DeserializeFromFile(string filename, XmlReaderSettings settings)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentException("filename", "XML filename cannot be null or empty");
            if (! File.Exists(filename))
                throw new FileNotFoundException("Cannot find XML file to deserialize", filename);
            // Create the stream writer with the specified encoding
            using (XmlReader reader = XmlReader.Create(filename, settings))
            {
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                return (T) xmlSerializer.Deserialize(reader);
            }
        }
    } 
