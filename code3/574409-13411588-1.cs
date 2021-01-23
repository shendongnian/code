    public static void insertRowBeforRowPPE(string strSelection, string strFileName)
    {
    
        XElement doc=XElement.Load(strFileName);
        foreach(XElement elm in doc.Descendants().Elements("PPE"))
        {
            if(elm.Element("UID").Value==strSelection)
            elm.AddBeforeSelf(new XElement("PPE",new XElement("UID","a2")));
            //adds PPE node having UID element with value a2 just before the required node
        }
    }
