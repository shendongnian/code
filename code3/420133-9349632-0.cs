    bool IsLetterWithDiacritics(char c)
    {
    	var s=c.ToString().Normalize(NormalizationForm.FormD);
    	return (s.Length>1)  &&
    	       char.IsLetter(s[0]) &&
    		   s.Skip(1).All(c2=>CharUnicodeInfo.GetUnicodeCategory(c2)==UnicodeCategory.NonSpacingMark);
    }
