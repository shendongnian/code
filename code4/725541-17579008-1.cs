    	private void cmdProcess_Click(object sender, EventArgs e)
    {
		foreach (string line in rtfMain.Lines)
		{
			if (!string.IsNullOrEmpty(line.Trim()))
			{
				if (line.StartsWith("***") || line.StartsWith("CUSIP"))
				{
					Quote q = new Quote();
					q.Parse(line);
					DisplayQuote(q);
					QuoteList.Add(q);
				}
			}
		}
    }
