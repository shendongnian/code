    foreach (GridViewRow gvr in GridView1.Rows)
    {  
     if(gvr.RowType == DataControlRowType.DataRow)
     {
        CheckBox cb = (CheckBox)gvr.FindControl("Checkbox1"); 
        if (cb.Checked)
        {
            double amount = Convert.ToDouble(gvr.Cells[2].Text);
            sum += amount;
        }
        Label1.Text = sum.ToString();
      }
    }
