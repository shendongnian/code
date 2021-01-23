    private void textbox_KeyDown(object sender, KeyEventArgs e)
    {
    	if (e.Control && e.KeyCode == Keys.V)
    	{
    		Clipboard.SetText((string)Clipboard.GetData("Text"), TextDataFormat.Text);
    	}
    }
