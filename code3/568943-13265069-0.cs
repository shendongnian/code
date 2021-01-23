        public void SerializeToXML(YourClass yourObj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(YourClass));
            System.IO.TextWriter textWriter = new StreamWriter(Application.StartupPath.Remove(Application.StartupPath.IndexOf("\\bin") + 5) + "Info.xml");
            serializer.Serialize(textWriter, yourObj);
            textWriter.Close();
        }
