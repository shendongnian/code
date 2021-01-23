    public static void AssignFallback(XElement xe, string name, string value)
    {
    	string varName = "(@" + name + ")";
    	XElement xep = xe.Descendants()
    			.FirstOrDefault(x => x.Name.LocalName == "p" && x.Value.Contains(varName));
    	if (xep == null)
    	{
    		return;
    	}
    	string prefix = "", sufix = "";
    	List<XElement> truns = new List<XElement>();
    	List<XElement> allruns = xep.Descendants().Where(x => x.Name.LocalName == "r").ToList();
    	for (int i = 0; i < allruns.Count; i++)
    	{
    		if (!allruns[i].Value.Contains("(@"))
    		{
    			continue;
    		}
    		int index = allruns[i].Value.IndexOf("(@");
    		prefix = allruns[i].Value.Substring(0, index);
    		truns.Clear();
    		truns.Add(allruns[i]);
    		string nameTemp = allruns[i].Value.Substring(index, allruns[i].Value.Length - index);
    		if (!varName.StartsWith(nameTemp))
    		{
    			continue;
    		}
    		for (int j = i + 1; j < allruns.Count; j++)
    		{
    			nameTemp += allruns[j].Value;
    			truns.Add(allruns[j]);
    			if (nameTemp.StartsWith(varName))
    			{
    				sufix = nameTemp.Substring(varName.Length);
    				break;
    			}
    			else if (nameTemp.Length > varName.Length)
    			{
    				break;
    			}
    		}
    		if (nameTemp.StartsWith(varName))
    		{
    			XElement xet = truns[0].Descendants().FirstOrDefault(x => x.Name.LocalName == "t");
    			xet.Value = prefix + value + sufix;
    			for (int j = 1; j < truns.Count; j++)
    			{
    				truns[j].Remove();
    			}
    		}
    	}
    }
