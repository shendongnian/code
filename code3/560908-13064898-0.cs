    drpdwnChaseSecSelection.DataSource = GetListItems(); // <-- Get your data from somewhere.
    drpdwnChaseSecSelection.DataValueField = "ValueProperty";
    drpdwnChaseSecSelection.DataTextField = "TextProperty";
    
    drpdwnChaseSecSelection.DataBind();
    
    bool viewNull = this._Row.Isxcs_ViewNull();
    if (!viewNull)
    {
        switch (this._Row.xcs_View.ToUpper())
        {
            case "RC": drpdwnChaseSecSelection.SelectedIndex=drpdwnChaseSecSelection.Items.IndexOf(drpdwnChaseSecSelection.Items.FindByText("Renewals Chasing")); break;
            case "D_RL":drpdwnChaseSecSelection.SelectedIndex=drpdwnChaseSecSelection.Items.IndexOf(drpdwnChaseSecSelection.Items.FindByText("Deal - Lettings")); break;
            case default: drpdwnChaseSecSelection.SelectedIndex=drpdwnChaseSecSelection.Items.IndexOf(drpdwnChaseSecSelection.Items.FindByText("None")); break;
        }
    }
    else
    {
        drpdwnChaseSecSelection.SelectedIndex=drpdwnChaseSecSelection.Items.IndexOf(drpdwnChaseSecSelection.Items.FindByText("None"));
    }
