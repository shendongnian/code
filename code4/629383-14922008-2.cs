    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
    	RadioButton rb = sender as RadioButton;
    	if (rb != null && rb.Checked)
    	{
    		int count = 0;
    		int txtBoxVisible = 3;
    
    		foreach (Control c in Controls)
    		{
    			if (count <= txtBoxVisible)
    			{
    				TextBox textBox = c as TextBox;
    				if (textBox != null) textBox.Visible = true; 
    				count++;
    			}
    		}
    	}
    }
    
    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {
    	RadioButton rb = sender as RadioButton;
    	if (rb != null && rb.Checked)
    	{
    		foreach (Control c in Controls)
    		{
    			TextBox textBox = c as TextBox;
    			if (textBox != null) textBox.Visible = true; 
    		}
    	}
    }
