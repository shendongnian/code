    private void Page_PreRender(object sender, System.EventArgs e)
    {
        if (formview1.CurrentMode == FormViewMode.Edit)
        {
            DropDownList ddl = formview1.FindControl("dropdownlist1");
            ddl.ClearSelection();
            var item = ddl.FindByValue("[MYVALUE]");
            if (item == null) ddl.SelectedIndex = 0;
            else item.Selected = true;
        }
    }
