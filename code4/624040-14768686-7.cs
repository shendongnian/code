    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        var dt = (DataTable)ViewState["CurrentData"];
    
        if (dt == null)
        {
            return;
        }
        
        List<DataRow> rowsToDelete = new List<DataRow>();
        foreach (GridViewRow row in GridView1.Rows)
        {        
            CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
            if (cb != null && cb.Checked)
            {
                row.Visible = false;
    
                //remove row by its index as it should GridViewRow index == DataRow index
                //it is not the best way but from your code I dont have information how your GridView looks
                rowsToDelete.Add(dt.Rows[row.RowIndex]);
            }
            else
            {
                Response.Write("Select check box to Delete");
            }
        }
      
        for (int i = 0; rowsToDelete.Count; i++)
        {
            dt.Rows.Remove(rowsToDelete[i]);
        }
    }
