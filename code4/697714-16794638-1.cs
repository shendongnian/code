    private void client_Advise(Object sender, NDde.Client.DdeAdviseEventArgs e)
    {
    	//Tests to consider:  Is it the right format?  Is it valid?  What's the state?
    
    	DataTable dt = new DataTable();  //replace with whatever data you *really are updating*
    	DataRow[] row = dt.Select("ALIASNUM = " + e.Item);
    	if (row.Length > 0)
    	row[0]["VALUE"] = e.Text;  //could use e.Data and convert from Byte[] to what you need (what is VALUE type?)
    }
