        /// make sure the XML doesn't have errors, such as non-printable characters
        private static bool IsXmlMalformed(string fileName)
        {
            var reader = new XmlTextReader(fileName);
            var result = false;
            try
            {
                while (reader.Read()) ;
            }
            catch (Exception e)
            {
                result = true;
            }
            return result;
        }
        /// Process the XML using deserializer and VS-generated XML proxy classes
        private static void ParseVisitedLinksListXml(string fileName, List<string> urlList, List<int> invalidUrls)
        {
            if (IsXmlMalformed(fileName))
                throw new Exception("XML is not well-formed.");
            using (var textReader = new XmlTextReader(fileName))
            {
                var serializer = new XmlSerializer(typeof(visited_links_list));
                if (!serializer.CanDeserialize(textReader))
                    throw new Exception("Can't deserialize this XML. Make sure the XML schema is up to date.");
                var list = (visited_links_list)serializer.Deserialize(textReader);
                foreach (var item in list.item)
                {
                    if (!string.IsNullOrEmpty(item.url) && !item.url.Contains(Environment.NewLine))
                        urlList.Add(item.url);
                    else
                        invalidUrls.Add(urlList.Count);
                }
            }
        }
