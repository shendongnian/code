    XElement xPkg = new XElement(myPackage.Name.ToString());
    foreach (EA.Element theElement in myPackage.Elements)
    {
        XElement xElem = new XElement(theElement.Name.ToString());
        xPkg.Add(xElem);
        foreach (EA.Attribute theAttribute in theElement.Attributes)
        {
            XElement xAttr = new XAttribute(theAttribute.Name.ToString(),
                                            theAttribute.Default.ToString()));
            xElem.Add(xAttr);
        }
    }
    TextWriter tw = new StreamWriter(myPackage.Name.ToString() + ".xml");
    tw.WriteLine(xPkg.ToString());
    tw.Close();
