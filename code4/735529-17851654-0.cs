    <asp:Panel id="TableContainer" 
         HorizontalAlign="Center" 
         runat="server">
    
       <!-- put your table(s) here -->
    
    </asp:Panel>
    protected void Page_Init(Object sender, EventArgs e)
    {
       var table1 = new Table();
       table1.ID = "Table1";
       for(int rowCtr = 1; rowCtr <= 10; rowCtr++) {
          // Create new row and add it to the table.
          TableRow tRow = new TableRow();
          table1.Rows.Add(tRow);
          for (int cellCtr = 1; cellCtr <= 10; cellCtr++) {
             // Create a new cell and add it to the row.
             TableCell tCell = new TableCell();
             tCell.Text = "Row " + rowCtr + ", Cell " + cellCtr;
             tRow.Cells.Add(tCell);
          }
       }
       TableContainer.Controls.Add(table1);
    }
