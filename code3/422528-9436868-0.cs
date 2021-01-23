    protected void GridViewRowDataBound(object sender, GridViewRowEventArgs e)
     {
         foreach (GridViewRow gvr in GridView1.Rows)
         {
             if (e.Row.Cells[2].Text == Session["Codice_ID"].ToString())
             {
                 e.Row.Cells[6].Visible = false;
                
             }
         }
     }
