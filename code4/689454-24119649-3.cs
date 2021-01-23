    protected void GridView10_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string cellt = e.Row.Cells[CORRECT CELL?].Tostring;
             if (cellt != "True") continue;
            {
                Button btn = (Button)e.Row.Cells[CORRECT CELL?].Controls[1];
                buttonname.visible = false;
                break;
            }
        }
