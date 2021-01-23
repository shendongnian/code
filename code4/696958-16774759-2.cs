        public string ObjectToXml<T>(T obj)
        {
            var stream = new StringWriter();
            string xmlDoc = string.Empty;
            try
            {
                var xmlSerializer = new XmlSerializer(typeof (T));
                xmlSerializer.Serialize(stream, obj);
                xmlDoc = stream.GetStringBuilder().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd pliku xml: " + ex);
            }
            finally
            {
                stream.Close();
            }
            return xmlDoc;
        }
        public static T XmlToObject<T>(string xmlDoc)
        {
            var stream = new MemoryStream();
            byte[] xmlObject = Encoding.Unicode.GetBytes(xmlDoc);
            stream.Write(xmlObject, 0, xmlObject.Length);
            stream.Position = 0;
            T message;
            var ss = new XmlSerializer(typeof (T));
            try
            {
                message = (T) ss.Deserialize(stream);
            }
            catch (Exception)
            {
                message = default(T);
            }
            finally
            {
                stream.Close();
            }
            return message;
        }
