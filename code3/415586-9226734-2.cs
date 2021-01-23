    protected void grdCAPRate_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           yourtype obj=  (yourtype)e.Row.DataItem;
                                           
               if (obj.DscStatus == "Andamento Project")    
                e.Row.BackColor = System.Drawing.Color.Navy;
              else
               e.Row.ForeColor=System.Drawing.Color.White;                                 
                                     
         }                
    }
