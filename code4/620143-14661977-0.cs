    rotected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Check for the row type, which should be data row
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find the check boxes and assign the values from the data source
                ((CheckBox)e.Row.FindControl("chkSelect")).Checked = Convert.ToBoolean(((DataRowView)e.Row.DataItem)[1]);
                ((CheckBox)e.Row.FindControl("chkAdd")).Checked = Convert.ToBoolean(((DataRowView)e.Row.DataItem)[2]);
                ((CheckBox)e.Row.FindControl("chkEdit")).Checked = Convert.ToBoolean(((DataRowView)e.Row.DataItem)[3]);
                ((CheckBox)e.Row.FindControl("chkAll")).Checked = Convert.ToBoolean(((DataRowView)e.Row.DataItem)[4]);
     
                //Find the checkboxes and assign the javascript function which should
                //be called when the user clicks the checkboxes.
     
                ((CheckBox)e.Row.FindControl("chkSelect")).Attributes.Add("onclick", "checkBoxClicked('" +
    ((CheckBox)e.Row.FindControl("chkSelect")).ClientID + "','" + ((CheckBox)e.Row.FindControl("chkAdd")).ClientID
    + "','" + ((CheckBox)e.Row.FindControl("chkEdit")).ClientID + "','" + ((CheckBox)e.Row.FindControl("chkAll")).ClientID + "'," + "'SELECT')");
     
                ((CheckBox)e.Row.FindControl("chkAdd")).Attributes.Add("onclick", "checkBoxClicked('" +
    ((CheckBox)e.Row.FindControl("chkSelect")).ClientID + "','" + ((CheckBox)e.Row.FindControl("chkAdd")).ClientID
    + "','" + ((CheckBox)e.Row.FindControl("chkEdit")).ClientID + "','" + ((CheckBox)e.Row.FindControl("chkAll")).ClientID + "'," + "'ADD')");
     
                ((CheckBox)e.Row.FindControl("chkEdit")).Attributes.Add("onclick", "checkBoxClicked('" +
    ((CheckBox)e.Row.FindControl("chkSelect")).ClientID + "','" + ((CheckBox)e.Row.FindControl("chkAdd")).ClientID
    + "','" + ((CheckBox)e.Row.FindControl("chkEdit")).ClientID + "','" + ((CheckBox)e.Row.FindControl("chkAll")).ClientID + "'," + "'EDIT')");
     
                ((CheckBox)e.Row.FindControl("chkAll")).Attributes.Add("onclick", "checkBoxClicked('" +
    ((CheckBox)e.Row.FindControl("chkSelect")).ClientID + "','" + ((CheckBox)e.Row.FindControl("chkAdd")).ClientID
    + "','" + ((CheckBox)e.Row.FindControl("chkEdit")).ClientID + "','" + ((CheckBox)e.Row.FindControl("chkAll")).ClientID + "'," + "'ALL')");
     
            }
        }
