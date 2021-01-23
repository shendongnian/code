    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton butIgnorar = new LinkButton()
                {
                   CommandName = "Ignorar",
                   ID = "butIgnorar",
                   Text = "Ignorar",
                   //optional: passes contents of cell 1 as parameter
                   CommandArgument =  e.Row.Cells[1].Text.ToString()
                };
                //Optional: to include some javascript cofirmation on the action
                butIgnorar.Attributes.Add("onClick", "javascript:return confirm('Are you sure you want to ignore?');");
                TableCell tc = new TableCell();
                tc.Controls.Add(butIgnorar);
                e.Row.Cells.Add(tc);
            }
        }
