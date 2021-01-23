    bool isRedBelow = averagesOriginal[0] < resultings[0];
    
    for (int i = 0; i < averagesOriginal.Count - 69; i++)
    {
    	int y = i + 35;
    	
    	if (isRedBelow && averagesOriginal[y] > resultings[i])
    	{
    		isRedBelow = false;
    		MessageBox.Show("Red is now above");
    	}
    	else if (!isRedBelow && averagesOriginal[y] < resultings[i])
    	{
    		isRedBelow = true;
    		MessageBox.Show("Red is now below");
    	}
    }
