    protected void Page_Load(object sender, EventArgs e)
    {
        UpdatePanel updatePanel = Page.Master.FindControl("UpdatePanel1") as UpdatePanel;
        UpdatePanelControlTrigger trigger  = new PostBackTrigger();
        trigger.ControlID = Announcement_Update.UniqueID;
        updatePanel.Triggers.Add(trigger);
    }
