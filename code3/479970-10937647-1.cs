    public IList<Alert> GetAlerts() 
    { 
        var xmlDoc1 = XDocument.Parse(XML, LoadOptions.None);
        var entries = xmlDoc1.Descendants("Notifications").Elements("Alerts").Select(s => new
        	List<string> {
        		s.Element("Max").Value,
        		s.Element("Med").Value,
        		s.Element("Min").Value
        	}).ToList();
        // Make sure we don't get an ArgumentOutOfRangeException
        if (entries.Count > 0)
        {
        	return entries[0];
        }
        else
        {
        	return new List<string>();
        }
    }
