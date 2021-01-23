        /// <summary>
        /// Serialize object
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static byte[] SerializeObject(object data)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            //empty namespace...
            ns.Add("", "");
            XmlSerializer xmlSerializer = new XmlSerializer(data.GetType());
            MemoryStream memStream = new MemoryStream();
            xmlSerializer.Serialize(memStream, data, ns);
            byte[] result = memStream.ToArray();
            memStream.Dispose();
            return result;
        }
