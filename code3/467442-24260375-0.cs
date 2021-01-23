    using (StringReader stream = new StringReader(xml))
    {
        XPathDocument document = new XPathDocument(stream);
        XPathNavigator navigator = document.CreateNavigator();
        XPathExpression expression = navigator.Compile("/path/to/element");
        XPathNodeIterator iterator = navigator.Select(expression);
        try
        {
            while (iterator.MoveNext())
            {
                XPathNavigator current = iterator.Current;
                string elementValue = current.Value;
                IXmlLineInfo lineInfo = current as IXmlLineInfo;
                if (lineInfo != null)
                {
                    int lineNumber = lineInfo.LineNumber;
                    int linePosition = lineInfo.LinePosition;
                }
            }
        }
        catch
        {
        }
    }
