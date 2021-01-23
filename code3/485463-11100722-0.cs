    if (((LinkButton)e.CommandSource).Text == "Edit1") //The Title of EditColumn 1
    {
        rgCases.MasterTableView.EditFormSettings.UserControlName = "WebUC1.ascx";
    }
    else
    {
        rgCases.MasterTableView.EditFormSettings.UserControlName = "WebUC2.ascx";
    }
