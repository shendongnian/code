    dataAdapter.RowUpdating +=  (sender, e) =>
    {
    	if (e.Command != null && !string.IsNullOrEmpty(e.Command.CommandText))
    	{
    	   e.Command.CommandText = $"";                                
    	}
    };
