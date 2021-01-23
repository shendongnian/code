    using (var wordDoc = WordprocessingDocument.Open(fileName, true))
    {
        MainDocumentPart mainPart = wordDoc.MainDocumentPart;
                
        using (Stream partStream = mainPart.GetStream())
        {
            var xmlDoc = new XmlDocument();
            using (XmlReader partXmlReader = XmlReader.Create(partStream))
                xmlDoc.Load(partXmlReader);
            //xml node manipulation here
            partStream.Position = 0;
            using (XmlWriter partXmlWriter = XmlWriter.Create(partStream))
                xmlDoc.Save(partXmlWriter);
        }
    }
