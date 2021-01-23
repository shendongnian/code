    void Main()
    {
    	var xml = @"<posters>
      <poster>
        <quantity>100</quantity>
        <stock>100</stock>
        <price>88</price>
      </poster>
      <poster>
        <quantity>100</quantity>
        <stock>150</stock>
        <price>95</price>
      </poster>
      <poster>
        <quantity>200</quantity>
        <stock>100</stock>
        <price>95</price>
      </poster>
      <poster>
        <quantity>200</quantity>
        <stock>150</stock>
        <price>100</price>
      </poster>
    </posters>";
    	var doc = XDocument.Parse(xml);
    	
	var value = (from x in doc.Descendants("poster")
			where x.Element("stock").Value == "100" 
			&& x.Element("quantity").Value == "200"
			select x.Element("price")).FirstOrDefault ();
    
    	if (value != null)
    		value.SetValue("1000");
    	
    	value.Dump();
    	doc.Dump();
    }
