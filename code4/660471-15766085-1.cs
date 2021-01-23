    class MyClass
    {
        private string CurrentCategory{ get; set; }
    
        // Load_Page with databinding the GridView{  }
    
        protected void mygridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow && 
              (e.Row.DataItem as DataRowView)["mycolumn"].ToString() != CurrentCategory))
            {
                GridViewRow tr = new GridViewRow(e.Row.RowIndex +1, e.Row.RowIndex + 1, 
                                       DataControlRowType.DataRow, e.Row.RowState);
                TableCell newTableCell = new TableCell();
                newTableCell.Text = (e.Row.DataItem as DataRowView)["mycolumn"].ToString();
                CurrentCategory = (e.Row.DataItem as DataRowView)["mycolumn"].ToString();
                tr.Cells.Add(newTableCell);
    
                ((Table)e.Row.Parent).Rows.Add(tr);
            }
        }
    }
