    static char RemoveDiacritics(char c)
    {
    	string stFormD = c.ToString().Normalize(NormalizationForm.FormD);
    	StringBuilder sb = new StringBuilder();
    
    	for (int ich = 0; ich < stFormD.Length; ich++)
    	{
    		UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
    		if (uc != UnicodeCategory.NonSpacingMark)
    		{
    			sb.Append(stFormD[ich]);
    		}
    	}
    
    	return (sb.ToString()[0]);
    }
    
    switch(RemoveDiacritics(valToCheck))
    {
    	case 'e':
    		//...
    		break;
    	case 'a':
    		//...
    		break;
    		//...
    }
