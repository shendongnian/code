    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
            e.Row.Cells[iDelete].Controls.Add
                (new ImageButton
                {
                    ImageUrl = "Images/database_delete.png",
                    CommandArgument = e.Row.RowIndex.ToString(),
                    CommandName = "Delete",
                    ID = "imgDelete",
                    CssClass = "imgDelete",
                    OnClientClick = "return EmpDelete(e" + e.Row.Cells[iFNmae].Text + ");"
                });
        }
    }
