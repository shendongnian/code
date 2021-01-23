    public static class Xml
    {
        /// <summary>
        /// Converts an XDoc into a List<T> of entities
        /// </summary>
        /// <typeparam name="T">Any serializable object</typeparam>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static List<T> DeserializeCollection<T>(XDocument doc)
        {
            if (doc == null)
                return null;
    
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                XmlReader reader = doc.CreateReader();
                List<T> result = (List<T>)serializer.Deserialize(reader);
                reader.Close();
                return result;
            }
            catch (Exception e)
            {
                //perform logging / error handling
                return null;
            }
    
        }
    
        /// <summary>
        /// Converts a List<T> of entities into an XDoc.
        /// </summary>
        /// <typeparam name="T">Any serializable object</typeparam>
        /// <param name="paramList"></param>
        public static XDocument SerializeCollection<T>(List<T> paramList)
        {
            if (paramList == null)
                return null;
    
            XDocument doc = new XDocument();
    
            try
            {
                XmlSerializer serializer = new XmlSerializer(paramList.GetType());
                XmlWriter writer = doc.CreateWriter();
                serializer.Serialize(writer, paramList);
                writer.Close();
                return doc;
            }
            catch (Exception e)
            {
                //perform logging / error handling
                return null;
            }
    
        }
    }
