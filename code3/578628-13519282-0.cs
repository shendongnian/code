    using (StreamReader r = new StreamReader(guid.ToString()))
	{
	    string line;
        int linesCount;
        ArrayList result = new ArrayList();
	    while ((line = r.ReadLine()) != null && linesCount++ <= 200)
	    {
             result.AddRange(line.Split(','));
	    }
	}
