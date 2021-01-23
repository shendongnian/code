    **Handling SharePoint Page Modes .
    This works for me , i resolved my critical issue by using below lines.
    if (Microsoft.SharePoint.SPContext.Current.FormContext.FormMode == SPControlMode.Edit)
    {
        alert.Text = "EditMode2";
    }
    else
    {
        alert.Text = "ViewMode";
    }**
