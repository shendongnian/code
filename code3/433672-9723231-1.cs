     public TextBox txtSearch = new TextBox();
             txtSearch.Text = "Goswami";
    
            protected void grd_RowDataBound(Object sender, GridViewRowEventArgs e)
            {           
                   
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        foreach(TableCell tc in e.Row.Cells)
                    {
                        tc.Text = tc.Text.Replace(txtSearch.Text, "<span style='color:Red;'>" + txtSearch.Text + "</span>");
                    }
                    
                    }            
            }
