    public void AddText(string Text)
    {
    	if (this.textBox1.InvokeRequired)
		{	
		   SetTextCallback d = new SetTextCallback(AddText); // Delegate
		   this.Invoke(d, new object[] { text });
		}
		else { this.textBox1.AppendText(text); }
    }
