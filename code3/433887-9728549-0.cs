    string search= textbox1.text;
    
    protected void grd_RowDataBound(Object sender, GridViewRowEventArgs e)
    {           
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            foreach(TableCell tc in e.Row.Cells)
            {
                if (tc.Controls.Count == 0){
                    tc.Text = tc.Text.Replace(search, "<span style='color:Red;'>" + search + "</span>");
                }
            }
        }            
    }
