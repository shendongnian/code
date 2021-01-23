    public string HelpText
    {
        get { return hidHelpText.Value; }
        set { hidHelpText.Value = value; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        imgHelp.Visible = !string.IsNullOrEmpty(HelpText);
        imgHelp.OnClientClick = string.Format("MsgBox({0}.value, MessageButtons.OK); return false;", hidHelpText.ClientID);
    }
