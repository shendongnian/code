    public class MediaQuery
    {
        public Dictionary<string, string> QueryFile(string filePath)
        {
            MediaInfo mediaInfo = new MediaInfo();
            string version = mediaInfo.Option("Info_Version");
            if (!File.Exists(filePath))
                throw new Exception("File Not Found");
            try
            {
                mediaInfo.Option("Inform", "XML");
                mediaInfo.Option("Complete", "1");
                mediaInfo.Open(filePath);
                string xml = mediaInfo.Inform();
                IEnumerable<XElement> el = XElement.Parse(xml, LoadOptions.None).Elements();
                XElement general = el.FirstOrDefault(e => e.Attribute("type").Value == "General");
                XElement video = el.FirstOrDefault(e => e.Attribute("type").Value == "Video");
                XElement audio = el.FirstOrDefault(e => e.Attribute("type").Value == "Audio");
                Dictionary<string, string> values = new Dictionary<string, string>();
                values = GetValues(general, "General");
                values = GetValues(video, "Video", values);
                values = GetValues(audio, "Audio", values);
                return values;
            }
            catch (Exception ex)
            {
                throw new Exception("Problem Querying File", ex);
            }
        }
        private Dictionary<string, string> GetValues(XElement xElement, string rootType)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            return GetValues(xElement, rootType, values);
        }
        private Dictionary<string, string> GetValues(XElement xElement, string rootType, Dictionary<string, string> values)
        {
            foreach (XElement element in xElement.Elements())
            {
                string key = rootType + "/" + element.Name.ToString();
                if (!values.ContainsKey(key))
                    values.Add(key, element.Value.ToString());
                else
                {
                    int count = 1;
                    key = rootType + "/" + element.Name.ToString() + count.ToString();
                    while (values.ContainsKey(key))
                    {
                        count++;
                        key = rootType + "/" + element.Name.ToString() + count.ToString();
                    }
                    values.Add(key, element.Value.ToString());
                }
            }
            return values;
        }
    }
