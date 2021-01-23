    TableRow tbody = new TableRow();
    tbody.TableSection = TableRowSection.TableBody;
    TableCell cell = new TableCell();
    tbody.Attributes.Add("data-filter", "featured");
    cell.Text = "Featured";
    tbody.Cells.Add(cell);
    Table1.Rows.Add(tbody);
