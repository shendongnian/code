    private void showKeys(object sender, KeyEventArgs e)
    {
    	List<string> keys = new List<string>();
    
    	if (e.Control == true)
    	{
    		keys.Add("CTRL");
    	}
    
    	if (e.Alt == true)
    	{
    		keys.Add("ALT");
    	}
    
    	if (e.Shift == true)
    	{
    		keys.Add("SHIFT");
    	}
    
    	switch (e.KeyCode)
    	{
    		case Keys.ControlKey:
    		case Keys.Alt:
    		case Keys.ShiftKey:
    		case Keys.Menu:
    			break;
    		default:
    			keys.Add(e.KeyCode.ToString()
    				.Replace("Oem", string.Empty)
    				);
    			break;
    	}
    
    	e.Handled = true;
    
    	textBox1.Text = string.Join(" + ", keys);
    }
