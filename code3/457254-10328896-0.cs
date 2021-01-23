    private string chkGridColHeaderId = string.Empty;
    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                CheckBox chkAll = (CheckBox)e.Row.FindControl("chkSelectAll");
                chkAll.Attributes.Add("onclick", "SelectAll(this.checked)");
                chkGridColHeaderId = chkAll.ClientID;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
                chkSelect.Attributes.Add("onclick", "if(!this.checked)document.getElementById('" + chkGridColHeaderId + "').checked = false;");
            }
        }
