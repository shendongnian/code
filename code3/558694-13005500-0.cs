    foreach (GridViewRow gvr in GridView1.Rows)
    {  
        CheckBox cb = (CheckBox)gvr.FindControl("Checkbox1"); 
        if (cb.Checked)
        {
            double amount = Convert.ToDouble(gvr.Cells[2].Text.replace("&nbsp",""));
            sum += amount;
        }
        Label1.Text = sum.ToString();
    }
