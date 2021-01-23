    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Xml;
    using System.Xml.Serialization;
    /// <summary>
    /// The XMLManager can be used to serialize to and from XML files.
    /// </summary>
    /// <typeparam name="T">The type to serialize.</typeparam>
    public static class XmlManager<T>
    {
        /// <summary>
        /// Static method SerializeFromFile
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <returns>
        /// returns T
        /// </returns>
        public static T SerializeFromFile(string path)
        {
            try
            {
                using (var xmlStream = new FileStream(path, FileMode.Open))
                {
                    return FromStream(xmlStream);
                }
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    
        /// <summary>
        /// Method FromStream
        /// </summary>
        /// <param name="xmlStream">
        /// The xml stream.
        /// </param>
        /// <returns>
        /// returns T
        /// </returns>
        public static T FromStream(Stream xmlStream)
        {
            try
            {
                var xmlReader = XmlReader.Create(xmlStream);
                var serializer = new XmlSerializer(typeof(T));
    
                var value = (T)serializer.Deserialize(xmlReader);
                return value;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    
        /// <summary>
        /// Method SerializeToFile
        /// </summary>
        /// <param name="xmlObject">
        /// The xml object.
        /// </param>
        /// <param name="xmlPath">
        /// The xml path.
        /// </param>
        /// <param name="overwriteExisting">
        /// The overwrite existing.
        /// </param>
        public static void SerializeToFile(T xmlObject, string xmlPath, bool overwriteExisting)
        {
            try
            {
                var mode = overwriteExisting ? FileMode.Create : FileMode.CreateNew;
                using (var xmlStream = new FileStream(xmlPath, mode))
                {
                    ToStream(xmlObject, xmlStream);
                }
            }
            catch (Exception ex)
            {
            }
        }
    
        /// <summary>
        /// Method ToStream
        /// </summary>
        /// <param name="xmlObject">
        /// The xml object.
        /// </param>
        /// <param name="xmlStream">
        /// The xml stream.
        /// </param>
        public static void ToStream(T xmlObject, Stream xmlStream)
        {
            try
            {
                var xmlSettings = new XmlWriterSettings { Indent = true, NewLineOnAttributes = false };
    
                var writer = XmlWriter.Create(xmlStream, xmlSettings);
                var serializer = new XmlSerializer(typeof(T));
    
                serializer.Serialize(writer, xmlObject);
            }
            catch (Exception ex)
            {
            }
        }
    }
