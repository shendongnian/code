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
                Logging.Log(Severity.Error, "Unable to deserialize document.", e);
                return null;
            }
        }
