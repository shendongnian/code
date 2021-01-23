    foreach (MSWord.Paragraph paragraph in doc.Paragraphs)
    {
    	if (paragraph.Next() != null)
    	{
    		if (IsHeading(paragraph))
    		{
    			myList.Add(paragraph.Range.Text.ToString());
    		}
    	}
    }
    
    private static bool IsHeading(MSWord.Paragraph paragraph)
    {
    	float para1FontSize = 0;
    	float para2FontSize = 0;
    	bool para1IsBold = false;
    	bool para2IsBold = false;
    
    	para1FontSize = paragraph.Range.Font.Size;
    	para2FontSize = paragraph.Next().Range.Font.Size;
    	para1IsBold = paragraph.Range.Font.Bold.Equals(1);
    	para2IsBold = paragraph.Next().Range.Font.Bold.Equals(0);
    
    	return ((para1FontSize > para2FontSize) || (para1IsBold && !para2IsBold));
    }
