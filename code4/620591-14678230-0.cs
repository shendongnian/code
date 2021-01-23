        ArrayList array = new ArrayList();
        Rules tempObj = new Rules { onE = "Value", min = 45, eN = "Value" };
        array.Add(tempObj);
        string result = SerializeArrayList(array);
        private string SerializeArrayList(ArrayList obj)
        {
            XmlDocument doc = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(ArrayList), new Type[]{typeof(Rules)});
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                try
                {
                    serializer.Serialize(stream, obj);
                    stream.Position = 0;
                    doc.Load(stream);
                    return doc.InnerXml;
                }
                catch (Exception ex)
                {
                }
            }
            return string.Empty;
        }
