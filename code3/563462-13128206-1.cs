    public void AddLineToTextBox(string line)
    {
    	if (textBox1.InvokeRequired)
    		textBox1.Invoke(new Action(() => { textBox1.Text += line + Environment.NewLine; }));
    	else
    		textBox1.Text += line + Environment.NewLine;
    }
