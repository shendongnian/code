    var dt = FunctionThatReturnDataTable(id)
    ...
    var p = new DocumentFormat.OpenXml.Wordprocessing.Paragraph(
      new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties(
               new Justification() { Val = JustificationValues.Center }),
                             new DocumentFormat.OpenXml.Wordprocessing.Run(new Text("Some Text")));
    body.Append(p);
    mainPart.Document.Append(body);
    mainPart.Document.Body.Append(CreateTable(dt));    
    ...
    // Creates an open xml table from the provided data table.
    public static Table CreateTable(System.Data.DataTable dt)
    {
      Table table = new Table();
      TableProperties tableProperties = new TableProperties();
      TableStyle tableStyle = new TableStyle() { Val = "MyStyle" };
      
      TableWidth tableWidth = new TableWidth() 
       { 
         Width = "0", 
         Type = TableWidthUnitValues.Auto 
       };
      TableLook tableLook = new TableLook() { Val = "04A0" };
      tableProperties.Append(tableStyle);
      tableProperties.Append(tableWidth);
      tableProperties.Append(tableLook);
      TableGrid tableGrid = new TableGrid();
      // Calculate column width in twentieths of a point (same width for every column).
      // 595=A4 paper width in points.
      int colWidth = (int)((595 / (float)dt.Columns.Count) * 20.0f);
      
      // Create columns
      foreach (DataColumn dc in dt.Columns)
      {
        tableGrid.Append(new GridColumn() { Width = colWidth.ToString() });
      }  
      table.Append(tableProperties);
      table.Append(tableGrid);
      // Create rows.
      foreach (DataRow dr in dt.Rows)
      {
        TableRow tableRow = new TableRow() 
         { 
           RsidTableRowAddition = "00C5307B", 
           RsidTableRowProperties = "00C5307B" 
         };
        // Create cells.
        foreach (object c in dr.ItemArray)
        {
          TableCell tableCell = new TableCell();
          TableCellProperties tableCellProperties = new TableCellProperties();
    
          TableCellWidth tableCellWidth = new TableCellWidth() 
            { 
              Width = colWidth.ToString(), 
              Type = TableWidthUnitValues.Dxa 
            };
          tableCellProperties.Append(tableCellWidth);
          Paragraph paragraph = new Paragraph() 
               { 
                 RsidParagraphAddition = "00CC797A", 
                 RsidRunAdditionDefault = "00CC797A" 
               };
          Run run = new Run();
          
          Text text = new Text();
          text.Text = c.ToString();
          run.Append(text);
          paragraph.Append(run);
          tableCell.Append(tableCellProperties);
          tableCell.Append(paragraph);
          tableRow.Append(tableCell);
        }
        table.Append(tableRow);
      }
  
      return table;
    }
