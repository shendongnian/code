    public static bool IsFlowDocument(this string xamlString)
    {
        if (xamlString.IsNullOrEmpty()) 
            throw new ArgumentNullException();
        if (xamlString.StartsWith("<") && xamlString.EndsWith(">"))
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.LoadXml(string.Format("<Root>{0}</Root>", xamlString));
                return true;
            }
            catch (XmlException)
            {
                return false;
            }
        }
        return false;
    }
    public static FlowDocument toFlowDocument(this string xamlString)
    {
        if (IsFlowDocument(xamlString))
        {
            var stringReader = new StringReader(xamlString);
            var xmlReader = System.Xml.XmlReader.Create(stringReader);
            return XamlReader.Load(xmlReader) as FlowDocument;
        }
        else
        {
            Paragraph myParagraph = new Paragraph();
            myParagraph.Inlines.Add(new Run(xamlString));
            FlowDocument myFlowDocument = new FlowDocument();
            myFlowDocument.Blocks.Add(myParagraph);
            return myFlowDocument;
        }
    }
