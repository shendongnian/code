    protected void Page_Load(object sender, EventArgs e)
    {
        // create the control dynamically
        LinkButton lbOneMore = new LinkButton();
       
        // the text and the commands
        lbOneMore.Text = "One more click";        
        lbOneMore.CommandArgument = "cArg";
        lbOneMore.CommandName = "CName";
        // the click handler
        lbOneMore.Click += new EventHandler(lbOneMore_Click);
        // and now add this button link to your div
        DivControl.Controls.Add(lbOneMore);
    }
    // here you come with the click, and the sender contains the commands
    void lbOneMore_Click(object sender, EventArgs e)
    {
        txtDebug.Text += "<br> Command: " + ((LinkButton)sender).CommandArgument;
    }
