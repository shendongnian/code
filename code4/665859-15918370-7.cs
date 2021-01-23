    void Main()
    {
    	//Serialize, but ignore properties that do not have XmlElementAttribute
    	var overrides = new XmlAttributeOverrides();
    	var attributes = new XmlAttributes();
    	attributes.XmlIgnore = true;
    	foreach(var prop in typeof(MyClass).GetProperties())
    	{
    		var attrs = prop.GetCustomAttributes(typeof(XmlElementAttribute));
    		if(attrs.Count() == 0)
    			overrides.Add(prop.DeclaringType, prop.Name, attributes);
    	}
    
    	using(var sw = new StringWriter()) {
    		var xs = new XmlSerializer(typeof(MyClass), overrides);
    		var a = new MyClass() { 
    								Company = "Company Name", 
    								Amount = 10M, 
    								companyid = 7,
    								blah = "123" };
    		xs.Serialize(sw, a);
    		Console.WriteLine(sw.ToString());
    	}
    }
    
    [Serializable]
    public class MyClass
    {
        [XmlElement("Company")]
        public string Company { get; set; }
    
        [XmlElement("Amount")]
        public decimal Amount { get; set; }
    
        public int companyid { get; set; }
    	
        public string blah { get; set; }
    }
