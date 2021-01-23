        public void ReadXml(XmlReader reader)
        {
            var data = int.Parse(reader.GetAttribute("Data"));
            var name = reader.GetAttribute("Name");
            this = new ImmutableData(data, name);
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Data", data.ToString());
            writer.WriteAttributeString("Name", name);
        }
