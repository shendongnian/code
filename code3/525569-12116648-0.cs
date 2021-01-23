        public static void ReplaceCustomXML(string fileName, string customXML)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(fileName, true))
            {
                MainDocumentPart mainPart = wordDoc.MainDocumentPart;
                mainPart.DeleteParts<CustomXmlPart>(mainPart.CustomXmlParts);
                //Add a new customXML part and then add the content. 
                CustomXmlPart customXmlPart = mainPart.AddCustomXmlPart(CustomXmlPartType.CustomXml);
                //Copy the XML into the new part. 
                using (StreamWriter ts = new StreamWriter(customXmlPart.GetStream())) ts.Write(customXML);
            }
        }
        public static string SerializeObjectToString(this object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer x = new XmlSerializer(obj.GetType());
                x.Serialize(stream, obj);
                return Encoding.Default.GetString(stream.ToArray());
            }
        }
