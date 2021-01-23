    protected void Exmplgrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                LinkButton btnSort = (LinkButton)e.Row.Cells[0].Controls[0];
                btnSort.Text = "This is changed header 1";
                btnSort = (LinkButton)e.Row.Cells[1].Controls[0];
                btnSort.Text = "This is changed header 2";
                btnSort = (LinkButton)e.Row.Cells[2].Controls[0];
                btnSort.Text = "This is changed header 2";
                e.Row.Cells[3].Text = "This is changed header 2. SORTING DISABLED"
            }
           
        }
