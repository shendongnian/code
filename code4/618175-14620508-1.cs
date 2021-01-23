    IDataObject iData = Clipboard.GetDataObject();
    if (iData.GetDataPresent(DataFormats.Html))
    {
        ClipboardHtmlOutput cho = ClipboardHtmlOutput.ParseString((string)iData.GetData(DataFormats.Html));
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(cho.Fragment);
    }
