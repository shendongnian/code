        protected void grdCAPRate_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                  HtmlContainerControl divstatus = e.Rows[i].FindControl("divstatus"); 
                            
                if (divstatus != null)                             
                 {                                 
                     if (divstatus.InnerText == "Andamento Project")    
                                           e.Row.BackColor = System.Drawing.Color.Navy;
                  
   
    else                                        e.Row.ForeColor=System.Drawing.Color.White;                                 
                       }                             
                     }                
              }
                 }
