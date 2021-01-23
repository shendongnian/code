    private void fillDate(int offset)
    {
    	int rows = 2;
    	int columns = 5;
    	int currentEntry = 1;
    	
    	for(int rowIndex = 0; rowIndex < rows; rowIndex++)
    	{
    		for (int columnIndex = 0; columnIndex < columns; columnIndex++)
    		{
    			if (currentEntry > offset)
    			{
    				TextBlock textEntry = new TextBlock();
    				textEntry.Text = currentEntry.ToString();
    				Grid.SetRow(textEntry, rowIndex);
    				Grid.SetColumn(textEntry, columnIndex);
    			}
    			currentEntry++;
    		}
    	}
    }
