    public class TextToHighlightedTextConverter : IMultiValueConverter
    {
    	public Style HighlightedTextStyle { get; set; }
    
    	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    	{
    		if (values.Length > 0)
    		{
    			if (values.Length > 1)
    			{
    				var text = values[0] as string;
    				var searchText = values[1] as string;
    				if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(searchText))
    				{
    					var textParts = GetSplittedText(text, searchText);
    					var textBlock = new TextBlock();
    					foreach (string textPart in textParts)
    					{
    						textBlock.Inlines.Add(textPart.Equals(searchText, StringComparison.OrdinalIgnoreCase)
    													? new Run(textPart) {Style = HighlightedTextStyle ?? new Style()}
    													: new Run(textPart));
    					}
    					return textBlock;
    				}
    			}
    			return values[0];
    		}
    		return null;
    	}
    
    	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    	{
    		throw new NotImplementedException();
    	}
    
    	private IEnumerable<string> GetSplittedText(string text, string searchText)
    	{
    		IList<string> textParts = new List<string>();
    		if (string.IsNullOrEmpty(searchText))
    		{
    			if (text.Length > 0)
    			{
    				textParts.Add(text);
    			}
    		}
    		else
    		{
    			while (text.Length > 0)
    			{
    				int searchIndex = text.IndexOf(searchText, StringComparison.OrdinalIgnoreCase);
    				if (searchIndex > -1)
    				{
    					if (searchIndex > 0)
    					{
    						string textInFrontOfMatch = text.Substring(0, searchIndex);
    						textParts.Add(textInFrontOfMatch);
    					}
    					textParts.Add(text.Substring(searchIndex, searchText.Length));
    					text = text.Remove(0, searchIndex + searchText.Length);
    				}
    				else
    				{
    					textParts.Add(text);
    					text = string.Empty;
    				}
    			}
    		}
    		return textParts;
    	}
    }
