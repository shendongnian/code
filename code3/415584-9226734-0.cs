        protected void grdCAPRate_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                  HtmlContainerControl divstatus = e.Rows[i].FindControl("divstatus");                             
    if (divstatus != null)                             
    {                                 
    if (divstatus.InnerText == "Andamento Project")                                 {                                     
    GridView1.Rows[i].BackColor = System.Drawing.Color.Navy;
    GridView1.Rows[i].ForeColor = System.Drawing.Color.White;                                 
    }                             
    }                
      e.Row.BackColor =  System.Drawing.Color.Navy; 
                }
             }
