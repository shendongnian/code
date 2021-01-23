    private void TextBox1_KeyUp(System.Object sender, System.Windows.Forms.KeyEventArgs e)    {
    
    	if (e.KeyCode == Keys.Return) {
    		
            string[] TextLines = TextBox1.Text.Split(Environment.NewLine);
    
    		TextBox1.Text = "";    
    
    		foreach ( txLine in TextLines) {
    
    			if (!txLine.Contains("*") & !string.IsNullOrEmpty(txLine.Trim)) {
    				txLine = "* " + txLine;    
    			}
    
    			TextBox1.Text += (txLine + Environment.NewLine);    
    		}
    
    		TextBox1.SelectionStart = TextBox1.Text.Length;
    		TextBox1.ScrollToCaret();
    	}    
    }
