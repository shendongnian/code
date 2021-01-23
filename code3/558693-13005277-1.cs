    foreach (GridViewRow gvr in GridView1.Rows)
    {  
     if(gvr.RowType == DataControlRowType.DataRow)
     {
        CheckBox cb = (CheckBox)gvr.FindControl("Checkbox1"); 
        if (cb.Checked)
        {
            //check wether the cell value is empty or not, if empty take a 0 instead...
            double amount = gvr.Cells[2].Text.Trim() != null && gvr.Cells[2].Text.Length>0 ? Convert.ToDouble(gvr.Cells[2].Text.Trim()) : 0;
            sum += amount;
        }
        Label1.Text = sum.ToString();
      }
    }
