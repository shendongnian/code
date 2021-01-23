     protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
     {
     
     if(cell_type == 'string')
         {
            e.Row.Cells[cell_index].HorizontalAlign = HorizontalAlign.Left;
         }else if(cell_type == 'decimal')
        {
                 e.Row.Cells[cell_index].HorizontalAlign = HorizontalAlign.Right;
         }
            
      }
