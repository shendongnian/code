    string lastSaved;
    
    private void Form_Load(object sender, System.EventArgs e)
    {
       // Load the form then save WebBrowser text
       this.lastSaved = this.webBrowser1.DocumentText;
    }
    
    private void webBrowser1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        // Check if it changed
        if (this.lastSaved != this.webBrowser1.DocumentText)
        {
            // TODO: changed, enable save button
            this.lastSaved = this.webBrowser1.DocumentText;
        }
    }
    
    private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
    {
        // Check if it changed
        if (this.lastSaved != this.webBrowser1.DocumentText)
        {
            // TODO: ask user if he wants to save
            // You can set e.Cancel = true to cancel loading the next page
        }
    }
