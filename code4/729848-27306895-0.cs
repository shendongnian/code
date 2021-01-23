    private void ComboBox_KeyDown(object sender, KeyEventArgs e)
    {
    	if (ComboBox.Text.Length > 19) // allow max 20 chars
    	{
    		e.Handled = true; // block any additional key press if there is more than allowed max
    		System.Media.SystemSounds.Beep.Play(); // optional: beep to let user know he is out of space :)
    	}
    }
