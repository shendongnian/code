    void Main()
    {
    	//Serialize, but ignore companyid
    	var overrides = new XmlAttributeOverrides();
    	var attributes = new XmlAttributes();
    	attributes.XmlIgnore = true;
    	overrides.Add(typeof(MyClass), "companyid", attributes);
    
    	using(var sw = new StringWriter()) {
    		var xs = new XmlSerializer(typeof(MyClass), overrides);
    		var a = new MyClass() { 
                                           Company = "Company Name", 
                                           Amount = 10M, 
                                           companyid = 7 
                                       };
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
    }
