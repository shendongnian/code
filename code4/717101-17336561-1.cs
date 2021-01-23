    public static void Assign(XElement xe, string name, string value)
    {
    	XElement el = xe.Descendants()
    		.FirstOrDefault(e => e.Name.LocalName == "t" && e.Value.Contains("(@" + name + ")"));
    	if (el != null)
    	{
    		el.Value = el.Value.Replace("(@" + name + ")", value);
    	}
        else
        {
            AssignFallback(xe, name, value);
        }   
    }
