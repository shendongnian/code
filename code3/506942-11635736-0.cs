        public static XDocument Serialize<T>(T objectIn, Type[] extraTypes)
        {
            try
            {
                var target = new XDocument();
                XmlSerializer s = extraTypes != null ? new XmlSerializer(objectIn.GetType(), extraTypes) : new XmlSerializer(objectIn.GetType());
                s = extraTypes != null
                    ? new XmlSerializer(objectIn.GetType(), extraTypes)
                    : new XmlSerializer(objectIn.GetType());
                var writer = target.CreateWriter();
                s.Serialize(writer, objectIn);
                writer.Close();
                return target;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Could not serialize object: {0}", ex.Message));
            }
        }
        public static T Deserialize<T>(XDocument xDocument, string defaultNamespace)
        {
            XmlSerializer s = new XmlSerializer(typeof(T), defaultNamespace);
            T result = (T)s.Deserialize(xDocument.CreateReader());
            return result;
        }
