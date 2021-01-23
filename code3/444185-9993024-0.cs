    List<XElement> lstXElements = new List<XElement>();
            lstXElements.AddRange(GetDescendants("NextItem"));
            lstXElements.AddRange(GetDescendants("PreviousItem"));
            List<Extract> lstExtract = new List<Extract>();
            foreach (XElement objElement in lstXElements)
            {
                Extract objExtract = new Extract();
                objExtract._id = Convert.ToInt32(objElement.Attribute("id").Value);
                objExtract.name = (objElement.Name).LocalName;
                lstExtract.Add(objExtract);
            }
    List<XElement> GetDescendants(string strDescentName)
        {
            return ((XDocument.Load(Server.MapPath("XMLFile1.xml"))
                .Descendants(strDescentName))
                ).ToList<XElement>();
        }
