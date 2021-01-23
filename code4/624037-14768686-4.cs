    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        var dt = (DataTable)ViewState["CurrentData"];
    
        if (dt == null)
        {
            return;
        }
    
        foreach (GridViewRow row in GridView1.Rows)
        {        
            CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
            if (cb != null && cb.Checked)
            {
                row.Visible = false;
    
                //remove row by its index as it should GridViewRow index == DataRow index
                //it is not the best way but from your code I dont have information how your GridView looks
                dt.Rows.RemoveAt(row.RowIndex);
    
                GridView1.DataSource = dt;
                GridView1.DataBind();
    
                GridView2.DataSource = dt;
                GridView2.DataBind();
    
                ViewState["CurrentData"] = dt;
            }
            else
            {
                Response.Write("Select check box to Delete");
            }
        }
    }
