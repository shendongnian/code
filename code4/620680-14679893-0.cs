    using(IsolatedStorageFileStream stream = new IsolatedStorageFileStream("class.xml",FileMode.Create,file))
    {
         XmlWriterSettings setting = new XmlWriterSettings();
         setting.Indent = true;
         using (XmlWriter writer = XmlWriter.Create(stream, setting))
         {
             XmlSerializer serializer = new XmlSerializer(typeof(Student));
             serializer.Serialize(writer, new Student() { Name = "AhLim" });
         }
    }
