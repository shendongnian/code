        private List<Category> GetCategories(string xmlData)
        {
            List<Category> obj = null;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Category>), new XmlRootAttribute("categories"));
            StringReader reader = new StringReader(xmlData.Replace("&","&amp;"));
            using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(reader))
            {
                obj = (List<Category>)serializer.Deserialize(xmlReader);
            }
            return obj;
        }
