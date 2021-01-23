        public string ObjectToXml<T>(List<T> obj)
        {
            var stream = new StringWriter();
            string xmlDoc = string.Empty;
            try
            {
                var xmlSerializer = new XmlSerializer(typeof (List<T>));
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
