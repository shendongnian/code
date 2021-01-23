    using (FileStream fs = new FileStream(m_Filename, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
    {
       XmlReader reader = new XmlTextReader(fs);
       XmlSerializer deserializer = new XmlSerializer(typeof(BaseBoardTest));
       m_TestNodes = (BaseBoardTest)deserializer.Deserialize(reader);
       fs.Close();
    }
