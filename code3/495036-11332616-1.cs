    protected void RedoEdits_Click(Object sender, EventArgs e)
    {
        // Goes to Page_Load here with IsPostBack == true
        string trendsFileLocation = currDir + "\\" + reportDir + "\\" + trendsFile;
        string messagesFileLocation = currDir + "\\" + reportDir + "\\" + messagesFile;
        if (File.Exists(trendsFileLocation))
        {
            File.Delete(trendsFileLocation);
        }
        if (File.Exists(messagesFileLocation))
        {
            File.Delete(messagesFileLocation);
        }
        trendsXML.Clear();
    
        ViewReport_Click(null, null);
    }
