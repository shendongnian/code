     void ConvertToXml()
            {
                string xmlString = ConvertObjectToXMLString(GridDetails);
                // Save C# class object into Xml file
                XElement xElement = XElement.Parse(xmlString);
                xElement.Save(@"C:\Users\user\Downloads\userDetail.xml");
            }
     static string ConvertObjectToXMLString(object classObject)
        {
            string xmlString = null;
            XmlSerializer xmlSerializer = new XmlSerializer(classObject.GetType());
            using (MemoryStream memoryStream = new MemoryStream())
            {
                xmlSerializer.Serialize(memoryStream, classObject);
                memoryStream.Position = 0;
                xmlString = new StreamReader(memoryStream).ReadToEnd();
            }
            return xmlString;
        }
