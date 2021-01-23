    void Main()
    {
    	string input = "<test><vehiclenumber>123</vehiclenumber><form><form_id>1</form_id><datafield>";
    	input += "<fieldnumber>1</fieldnumber><data><datawords>";
    	input += "<datatext1>1234</datatext1><mc2>656865</mc2>";
    	input += "</datawords></data></datafield></form></test>";
    	
    	XDocument documentXDoc = XDocument.Parse(input);
    	IEnumerable<XElement> elements = documentXDoc.Descendants("test");
    
    	IEnumerable<Receipt> _fuelReceipts =  elements
    		.Select(receipt => new Receipt()
    		{
    			vehicle_number = receipt.Element("vehiclenumber") == null ? "" : receipt.Element("vehiclenumber").Value,
    			field = receipt.Descendants("datafield")
    			.Select(x => new Field()
    			{
    				field_number = x.Element("fieldnumber") == null ? "" : x.Element("fieldnumber").Value,
    				event_data = x.Elements("data").Descendants()
    					.Where(d => !d.HasElements)
    					.ToDictionary(d => d.Name.LocalName, d => d.Value)
    			}).ToList()
    		});
    }
    
    class Receipt {
    	public string vehicle_number { get; set; }
    	public List<Field> field { get; set; }
    }
    
    class Field {
    	public string field_number { get; set; }
    	public Dictionary<string, string> event_data { get; set; }
    }
