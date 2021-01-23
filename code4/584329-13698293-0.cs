    XmlDocument stripDocumentNamespace(XmlDocument oldDom)
    {
	XmlDocument newDom = new XmlDocument();
	newDom.LoadXml(System.Text.RegularExpressions.Regex.Replace(oldDom.OuterXml,@"(xmlns:?[^=]*=[""][^""]*[""])", "",System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Multiline));
	return newDom;
    } 
