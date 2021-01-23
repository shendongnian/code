    private void fillDate(int offset)
    {
    	int currentEntry = 1;
    	
    	for(int rowIndex = 0; rowIndex < Rows; rowIndex++)
    	{
    		for (int columnIndex = 0; columnIndex < Columns; columnIndex++)
    		{
    			TextBlock textEntry = TextEntries[rowIndex][columnIndex]
    			
    			if (currentEntry > offset)
    				textEntry.Text = currentEntry.ToString();
    			else
    				textEntry.Text = String.Empty;
    				
    			currentEntry++;
    		}
    	}
    }
