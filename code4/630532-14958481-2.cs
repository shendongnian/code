    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //Find the checkbox control in header and add an attribute
                ((CheckBox)e.Row.FindControl("cbSelectAll")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("cbSelectAll")).ClientID + "')");
                ((CheckBox)e.Row.FindControl("cbSelectAll1")).Attributes.Add("onclick", "javascript:SelectAll1('" + ((CheckBox)e.Row.FindControl("cbSelectAll1")).ClientID + "')");
            }
        }
