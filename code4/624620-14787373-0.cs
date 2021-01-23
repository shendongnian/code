     protected void Button2_Click(object sender, EventArgs e)
     {
        var dt = (DataTable)ViewState["CurrentData"];
        if (dt == null)
        {
            return;
        }
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("CheckBox2");
            if (cb != null && cb.Checked)
            {
                Label1.Visible = false;
                dt.Rows.RemoveAt(row.RowIndex);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView2.DataSource = dt;
                GridView2.DataBind();
                ViewState["CurrentData"] = dt;
            }
            else if (cb.Checked == false)
            {
                Label1.Visible = true;
            }
        }
        
    }
