    protected bool textChangedEnabled = true;
    private void cel_TextChanged(object sender, TextChangedEventArgs e)
    {
		if(textChangedEnabled)
		{
		    textChangedEnabled = false;
			if (cel.Text != "")
			{
				try
				{
					Double c = Convert.ToDouble(cel.Text);
					fahre.Text = "" + ((c *(9.0 / 5.0 )) + 32);
				}
				catch (FormatException)
				{
					fahre.Text = "";
					cel.Text = "";
				}
			}
			else
			{
				fahre.Text = "";
			}
			textChangedEnabled = true;
		}
    }
