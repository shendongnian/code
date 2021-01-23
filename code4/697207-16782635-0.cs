    foreach (Control control in Panel1.Controls)
    {
    	var textBox = control as TextBox;
    	if (textBox != null)
    	{
    		textBox.Visible = !string.IsNullOrEmpty(textBox.Text);
    	}
    }
