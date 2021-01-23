    public static void insertRowBeforRowPPE(string strSelection, string strFileName)
    {
      XElement doc=XElement.Load(strFileName);
      XElement project = doc.Element("Project");
      XElement ppe = project.Element("PPE");
      foreach(XElement elm in ppe.Elements("ppe")
      {
        if(elm.Element("UID").Value==strSelection)
          elm.AddBeforeSelf(new XElement("PPE",new XElement("UID","a2")));
          //adds PPE node having UID element with value a2 just before the required node
      }
      doc.Save(strFileName);
    }
