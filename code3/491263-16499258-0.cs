    public void WriteXml(XmlWriter writer)
        {
            foreach (var pair in _dictionary)
            {
                writer.WriteElementString("Key", pair.Key);
                writer.WriteElementString("Value", pair.Value.ToString());
            }
        }
