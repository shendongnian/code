    foreach(var elms in xdoc.Descendants("MedicationDispensed").Elements())
    {
    	if(elms.HasElements)
    	{
    		foreach (var element in elms.Elements())
    		{
    			Console.WriteLine (element.Name + ":" + element.Value.ToString());
    		}
    	}
    	else
    	{
    	 Console.WriteLine(elms.Name + ":" + elms.Value.ToString());
    	 }
    }
