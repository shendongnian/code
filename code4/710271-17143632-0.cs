    public static async Task Serialize(List<Zajecia> xml_List)
    {
        using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync("Plan list.xml", CreationCollisionOption.ReplaceExisting))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Zajecia>));
            using (XmlWriter xmlWriter = XmlWriter.Create(stream, new XmlWriterSettings() { Indent = true }))
            {
                serializer.Serialize(xmlWriter, xml_List);
            }
        }
    }
