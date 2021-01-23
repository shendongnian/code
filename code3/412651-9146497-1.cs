	public static class Helper
	{
	    public static bool TryParseDouble(this TextBox textbox, out double value)
	    {
	        if (double.TryParse(textbox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
	        {
	            textbox.Foreground = Brushes.Black; //indicates that the user typed correct number
	            return true;
	        }
	        else
	        {
	            textbox.Foreground = Brushes.Red; // not a number
	            return false;
	        }
        }
	}
