        public void SerializeToXML(YourClass yourObj)
        {
            if (!File.Exists(Application.StartupPath.Remove(Application.StartupPath.IndexOf("\\bin") + 5) + "Info.xml"))
                File.Create(Application.StartupPath.Remove(Application.StartupPath.IndexOf("\\bin") + 5) + "Info.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(YourClass));
            System.IO.TextWriter textWriter = new StreamWriter(Application.StartupPath.Remove(Application.StartupPath.IndexOf("\\bin") + 5) + "Info.xml");
            serializer.Serialize(textWriter, yourObj);
            textWriter.Close();
        }
