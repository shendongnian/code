    TextBoxParameterUserControlic control = LoadControl("~/Parameters/TextBoxParameterUserControl.ascx") as TextBoxParameterUserControl;
    if(control != null)
    {
        control.LabelPrompt = "AAAA"; 
        PanelParametersList.Controls.Add(p);
    }
