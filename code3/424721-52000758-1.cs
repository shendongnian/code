    if (Microsoft.SharePoint.SPContext.Current.FormContext.FormMode == SPControlMode.Edit)
    {
        alert.Text = "EditMode2";
    }
    else
    {
        alert.Text = "ViewMode";
    }
