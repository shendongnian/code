    if (Page.Master != null)
    {
        var tempPanel = Page.Master.FindControl("MessagePanel") as UpdatePanel;
        if (tempPanel != null)
            tempPanel.Visible = true;
                
        var temp = Page.Master.FindControl("MessageForUser") as MessageToUser;
        if (temp != null)
            temp.PostWarningMessage(message, msgInterval);
    }
