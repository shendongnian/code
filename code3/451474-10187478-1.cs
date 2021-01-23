    private void textBox2_KeyDown(object sender, KeyEventArgs e)
    {
    	if (e.KeyCode == Keys.PageDown ||
    		e.KeyCode == Keys.PageUp ||
    		e.KeyCode == Keys.Oemplus ||
            e.KeyCode == Keys.Add ||
    		(e.KeyCode == Keys.D0 && e.Shift))
    	{
    		textBox2.Text = textBox1.Text;
    		e.Handled = true;
    		e.SuppressKeyPress = true;
    	}
    }
