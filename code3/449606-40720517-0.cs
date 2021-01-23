    var Status = xn["Feature"];
    foreach (XmlElement element in Status){
    XElement withoutXmlnsElement =RemoveAllNamespaces(XElement.Parse(element.OuterXml));
     
      }
    
    
		public static XElement RemoveAllNamespaces(XElement e)
		{
			return new XElement(e.Name.LocalName,
		    (from n in e.Nodes()
			select ((n is XElement) ? RemoveAllNamespaces(n as XElement) : n)),
			(e.HasAttributes) ? (from a in e.Attributes() 
            where (!a.IsNamespaceDeclaration) select new     
            XAttribute(a.Name.LocalName,a.Value)) : null);
		}
    
