    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "remove")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (index >= 0)
            { 
                //index is the row, now obtain the RadioButtonList1 in this row
                RadioButtonList rbl = (RadioButtonList)GridView1.Rows[index].FindControl("RadioButtonList1");
                if (rbl != null)
                {
                    string selected = rbl.SelectedItem.Text;
                    Response.Write("Row " + index + " was selected, radio button " + selected);
                }
            }
        }
    }
