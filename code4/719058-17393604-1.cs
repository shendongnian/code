    void Main()
    {
    	var xmlSerializer = new XmlSerializer(typeof(Foo));
    	var foo1 = (Foo)xmlSerializer.Deserialize(new StringReader(@"<Foo a=""11""></Foo>"));
    	Console.WriteLine(foo1.A); // 11
    	
    	var foo2 = (Foo)xmlSerializer.Deserialize(new StringReader(@"<Foo></Foo>"));
    	Console.WriteLine(foo2.A); // 10 (fell back to the default)
    
    	// throws format exception
    	var foo3 = (Foo)xmlSerializer.Deserialize(new StringReader(@"<Foo a=""x""></Foo>"));
    }
    
    // Define other methods and classes here
    [XmlRoot("Foo")]
    public class Foo {
    	public Foo() { this.A = 10; }
    
    	[XmlAttribute("a")]
    	public int A { get; set; }
    }
