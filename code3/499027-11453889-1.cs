    public AcroFields loadAcroFields(String path)
    {
    	PdfReader pdfReader = new PdfReader(path);
    	AcroFields fields = pdfReader.AcroFields;
    	pdfReader.Close();
    	return fields;
    }
    public List<myKey> getKeys(AcroFields af)
    {
    	XfaForm xfa = af.Xfa;
    	List<myKey> Keys = new List<myKey>();
    	foreach (var field in af.Fields)
    	{
    		Keys.Add( new myKey(field.Key,  af.GetField(field.Key)));
    	}
    	if (xfa.XfaPresent)
    	{
    		System.Xml.XmlNode n = xfa.DatasetsNode.FirstChild;
    		Keys.AddRange(BFS(n));
    	}
    	return Keys;
    }
    
    public List<myKey> BFS(System.Xml.XmlNode n)
    {
    	List<myKey> Keys = new List<myKey>();
    	System.Xml.XmlNode n2 = n;
    
    	if (n == null) return Keys;
    			
    	if (n.FirstChild == null)
    	{
    		n2 = n;
    		if ((n2.Name.ToCharArray(0, 1))[0] == '#') n2 = n2.ParentNode;
    		while ((n2 = n2.NextSibling) != null)
    		{
    			Keys.Add(new myKey(n2.Name, n2.Value));
    		}
    	}
    
    	if (n.FirstChild != null)
    	{
    		n2 = n.FirstChild;
    		Keys.AddRange(BFS(n2));
    	}
    	n2 = n;
    	while ((n2 = n2.NextSibling) != null)
    	{
    		Keys.AddRange(BFS(n2));
    	}
    	return Keys;
    }
