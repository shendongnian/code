    private void cmdProcess_Click(object sender, EventArgs e)
    {
    	try
    	{		
    		foreach (string line in rtfMain.Lines)
    		{
    			try
    			{
    				if (string.IsNullOrEmpty(line.Trim()))
    				{
    					// This if statement always will be false.
    					if (line.StartsWith("***") && line.StartsWith("CUSIP"))
    					{
    						Quote q = new Quote();
    						q.Parse(line);
    						DisplayQuote(q);
    						QuoteList.Add(q);
    					}
    				}
    			}
    		}
    	}
    }
