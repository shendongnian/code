    TableRow row = new TableRow();
    TableCell cell = new TableCell();
    cell.Text = "Testing";
    cell.BackColor = System.Drawing.Color.Red;
    row.Cells.Add(cell);
    table.Rows.Add(row);
    
    table.Rows[0].Cells[0].BackColor = System.Drawing.Color.Pink;
