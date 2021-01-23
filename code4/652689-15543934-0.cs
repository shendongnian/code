    public static class Serializer<T>
    {
        public static T Deserialize(string path)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            System.IO.FileStream stream = null;
            try
            {
                stream = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                return (T)serializer.Deserialize(stream);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                }
            }
        }
        public static void Serialize(string path, T obj, bool createFolder = false)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            if (createFolder)
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));
            }
            using (System.Xml.XmlTextWriter xmlWriter = new System.Xml.XmlTextWriter(path, System.Text.Encoding.Unicode))
            {
                xmlWriter.Formatting = System.Xml.Formatting.Indented;
                serializer.Serialize(xmlWriter, obj);
                xmlWriter.Flush();
                xmlWriter.Close();
            }
        }
    }
