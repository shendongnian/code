    [System.Xml.Serialization.XmlType("base")]
    public class Base
    {
    	[System.Xml.Serialization.XmlElement("common")]
        public int Common { get; set; }
    }
    
    public class A : Base
    {
        public string ConcreteA { get; set; }
    }
    
    public class B : Base
    {
        public string ConcreteB { get; set; }
    }
    
    [System.Xml.Serialization.XmlRootAttribute("root")]
    public class Root : System.Xml.Serialization.IXmlSerializable
    {
    	[System.Xml.Serialization.XmlElement("base")]
        public List<Base> Bases { get; set; }
    	
    	 public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
    
        public void ReadXml(XmlReader reader)
        {
    		this.Bases = new List<Base>();
    		var document = XDocument.Load(reader);
    			
    		foreach (var element in document.Root.Elements())
    		{
    			Base baseElement = null;
    			
    			var attr = element.Attribute("type");
    			
    			if(attr.Value == "a")
    			{
    				var a = new A();
    				a.ConcreteA = element.Element("concreteA").Value;
    				baseElement = a;
    			}
    			else
    			{
    				var b = new B();
    				b.ConcreteB = element.Element("concreteB").Value;
    				baseElement = b;
    			}
    			
    			baseElement.Common = int.Parse(element.Element("common").Value);
    			this.Bases.Add(baseElement);
    		}
    		
    		this.Bases.Dump();
        }
    
        public void WriteXml(XmlWriter writer)
        {
            throw new NotSupportedException();
        }
    }
    
    void Main()
    {
    	var xmlString = @"<root>
        <base type=""a"">
            <common>1</common>
            <concreteA>one</concreteA>
        </base>
        <base type=""b"">
            <common>2</common>
            <concreteB>two</concreteB>
        </base>
    </root>";
    
    	var stream = new StringReader(xmlString);
    	var deserializer = new System.Xml.Serialization.XmlSerializer(typeof(Root));
    	var result = (Root)deserializer.Deserialize(stream);	
    }
