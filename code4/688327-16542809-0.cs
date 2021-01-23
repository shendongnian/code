    using (var context = new MyDbContext())
    {
        using (var writer = XmlWriter.Create(destinationFile))
        {
            var serializer = new XmlSerializer(typeof(Parent));
            writer.WriteStartElement("ArrayOfParent");
            foreach(Parent parent in BdContext.Parents)
            {
                serializer.Serialize(writer, parent);
            }
            writer.WriteEndElement();
        }
    }
