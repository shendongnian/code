    public static T DeserializeObject<T>(this string xml)
        {
            if (xml == null)
                throw new ArgumentNullException("xml");
            var xs = new XmlSerializer(typeof(T));
            var ms = new MemoryStream(new UTF8Encoding().GetBytes(xml));
            try
            {
                new XmlTextWriter(ms, Encoding.UTF8);
                return (T)xs.Deserialize(ms);
            }
            catch
            {
                return default(T);
            }
            finally
            {
                ms.Close();
            }
        }
