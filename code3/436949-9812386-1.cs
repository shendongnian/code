    XmlQualifiedName qn = XmlQualifiedName.Empty;
    if (xdoc.DocumentElement != null)
    {
            if (string.IsNullOrEmpty(xdoc.DocumentElement.NamespaceURI))
            {
                  qn = new XmlQualifiedName(xdoc.DocumentElement.LocalName);
            }
            else
            {
                   qn = new XmlQualifiedName(xdoc.DocumentElement.LocalName, xdoc.DocumentElement.NamespaceURI);
             }
    }
    return !(svh.HasError || qn.IsEmpty || (!xset.GlobalElements.Contains(qn)));
