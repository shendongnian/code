     public TextBox txtSearch = new TextBox();
             txtSearch.Text = "Goswami";
    
            protected void grd_RowDataBound(Object sender, GridViewRowEventArgs e)
            {           
                   
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        e.Row.Cells[4].Text = e.Row.Cells[4].Text.Replace(txtSearch.Text, "<span style='color:Red;'>" + txtSearch.Text + "</span>");
                        // 4 = Your Column Index where you have to search and apply your Color
                    }            
            }
