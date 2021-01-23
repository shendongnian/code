        public void SerializeToXML(YourClass yourObj)
        {
            if (!File.Exists("C:\\Info.xml"))
                File.Create("C:\\Info.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(YourClass));
            System.IO.TextWriter textWriter = new StreamWriter("C:\\Info.xml");
            serializer.Serialize(textWriter, yourObj);
            textWriter.Close();
        }
