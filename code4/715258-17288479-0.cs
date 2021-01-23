    class Program
    {
    	static void Main(string[] args)
    	{
    		var doc = new XmlDocument();
    		doc.Load(@"..\..\input.xml");
    			
    		var container = doc.DocumentElement
    			.GetElementsByTagName("Dealers")
    			.OfType<XmlElement>()
    			.FirstOrDefault();
    		if (container == null) return;
    
    		var dealers = container
    			.GetElementsByTagName("Dealer")
    			.OfType<XmlElement>();
    
    		foreach (var dealer in dealers)
    		{
    			var dealerId = dealer.GetAttribute("id");
    			Console.Write(dealerId + " - ");
    
    			var descrip = dealer.GetElementsByTagName("Description").OfType<XmlElement>().FirstOrDefault();
    			if (descrip != null)
    				Console.WriteLine(descrip.InnerText);
    				
    			// etc...
    		}
    		Console.ReadLine();
    	}
    }
