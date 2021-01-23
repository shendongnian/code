        if (Microsoft.SharePoint.SPContext.Current.FormContext.FormMode == SPControlMode.Edit)
        {
            ltr.Text = "EditMode2";
        }
        else
        {
            ltr.Text = "ViewMode";
        }
    
