    HtmlTableRow row = new HtmlTableRow();
    HtmlTableCell cell = new HtmlTableCell();
    cell.InnerText = "Text goes here.";
    row.Cells.Add(cell);
    
    this.Table1.Rows.Add(row);
