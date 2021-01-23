        /// <summary>
        /// Converts a List<T> of entities into an XDoc.
        /// </summary>
        /// <typeparam name="T">Any serializable object</typeparam>
        /// <param name="doc"></param>
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
                Logging.Log(Severity.Error, "Unable to serialize list", e);
                return null;
            }
        }
    }
