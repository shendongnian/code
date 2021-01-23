    protected void dvDatabase_DataBound(Object sender, EventArgs e)
    { 
        var view = (DetailsView)sender;
        var btnView = (Button)view.FindControl("btnView");
        var btnEdit = (Button)view.FindControl("btnEdit");
        switch (view.CurrentMode)
        { 
            case DetailsViewMode.ReadOnly:
                btnView.Visible = false;
                btnEdit.Visible = true;
                break;
            case DetailsViewMode.Edit:
                btnView.Visible = true;
                btnEdit.Visible = false;
                break;
            case DetailsViewMode.Insert:
                btnView.Visible = false;
                btnEdit.Visible = false;
                break;
            default:
                break;
        }
    }
