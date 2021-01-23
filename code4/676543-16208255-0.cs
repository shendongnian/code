    HtmlTable table = Control.FindControl("YourID");
    for (int m = 0; m < table.Rows.Count; m++)
    {
        for (int x = 0; x < table.Rows[m].Cells.Count, x++)
        {
            for (int c = 0; c < table.Rows[m].Cells[x].Controls.Count; c++)
            {
                if (typeof(table.Rows[m].Cells[x].Controls[c]) == typeof(CheckBox))
                {
                    if (((CheckBox)table.Rows[m].Cells[x].Controls[c]).Checked)
                    {     
                        //Your logic here
                    }
                }
            }
        }
    }
