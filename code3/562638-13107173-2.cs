    protected void Page_Load(object sender, EventArgs e)
    {
        String[,] cellValues = { { "1", "2", "3" }, { "a", "b", "c" }, { "m", "n", "o" } };
    
        HtmlTableRow row = new HtmlTableRow();
        HtmlTableCell cell = new HtmlTableCell();
    
        cell.ColSpan = 3;
        cell.InnerText = "Record 1";
        row.Cells.Add(cell);
        tableContent.Rows.Add(row);
    
        for (int i = 0; i < cellValues.GetLength(0); i++)
        {
            row = new HtmlTableRow();
            for (int j = 0; j < cellValues.GetLength(1); j++)
            {
                cell = new HtmlTableCell();
                cell.InnerText = cellValues[i, j];
                row.Cells.Add(cell);
            }
            tableContent.Rows.Add(row);
        }
    
        row = new HtmlTableRow();
        cell = new HtmlTableCell();
    
        HtmlInputButton input = new HtmlInputButton();
        input.ID = "Button1";
        input.Value = "button";
    
        cell.ColSpan = 3;
        cell.Controls.Add(input);
        row.Cells.Add(cell);
        tableContent.Rows.Add(row);
    }
