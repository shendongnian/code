        static byte[] buffer;
        public static object Read(XmlDocument xmlDocument)
        {
            if (buffer == null)
            {
                buffer = new byte[1024 * 1024 * 512];
            }
            if (xmlDocument != null)
            {
                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    xmlDocument.Save(ms);
                    ms.Flush();
                    ms.Seek(0, SeekOrigin.Begin);
                    object  result = ReadFromStream(ms);
                    ms.Close();
                    return result;
                }
            }
            else
            {
                return null;
            }
        }
