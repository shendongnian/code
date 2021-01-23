    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlTableRow row = new HtmlTableRow();
        HtmlTableCell cell = new HtmlTableCell();
    
        cell.ColSpan =3;
        cell.InnerText = "Record 1";
        row.Cells.Add(cell);
        tableContent.Rows.Add(row);
    
        row = new HtmlTableRow();
        cell = new HtmlTableCell();
    
        cell.InnerText = "1";
        row.Cells.Add(cell);
    
        cell = new HtmlTableCell();
        cell.InnerText = "2";
        row.Cells.Add(cell);
    
        cell = new HtmlTableCell();
        cell.InnerText = "3";
        row.Cells.Add(cell);
    
        tableContent.Rows.Add(row);
    
        row = new HtmlTableRow();
        cell = new HtmlTableCell();
    
        cell.InnerText = "a";
        row.Cells.Add(cell);
    
        cell = new HtmlTableCell();
        cell.InnerText = "b";
        row.Cells.Add(cell);
    
        cell = new HtmlTableCell();
        cell.InnerText = "c";
        row.Cells.Add(cell);
    
        tableContent.Rows.Add(row);
    
    
        row = new HtmlTableRow();
        cell = new HtmlTableCell();
        cell.InnerText = "m";
        row.Cells.Add(cell);
    
        cell = new HtmlTableCell();
        cell.InnerText = "n";
        row.Cells.Add(cell);
    
        cell = new HtmlTableCell();
        cell.InnerText = "o";
        row.Cells.Add(cell);
    
        tableContent.Rows.Add(row);
    
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
