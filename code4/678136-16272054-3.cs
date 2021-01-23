    protected void Button1_Click(Object sender, EventArgs e)
     {
        int ID = 0;
       Label5.Visible = false;
    
       ID = Convert.ToInt32(GridView1.Rows[row.RowIndex].Cells[1].Text);
    
    
      // somthing like 
      // Server.Transfer("~/Producter/Delete?id="+ id)
      // OR
      Response.Redirect("~/Producter/Delete?id="+ ID);
    
     }
