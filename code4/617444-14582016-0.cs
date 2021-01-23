    void Main()
    {
    	string p = @"http://events.feed.comportal.be/agenda.aspx?event=TechDays&year=2013&speakerlist=c%7CExperts";
    	using (var client = new WebClient())
    	{
    		string str = client.DownloadString(p);
    		var xml = XDocument.Parse(str);
    		
    		var result = xml.Descendants("speaker")
    		                .Select(speaker => GetNameOrDefault(speaker));
    				   
    		//LinqPad specific call		   
    		result.Dump();
    	}
    }
    public static string GetNameOrDefault(XElement element)
    {
    	var name = element.Element("fullname");
    	return name != null ? name.Value : "no name";
    }
