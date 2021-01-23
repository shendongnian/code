    public static DataTable ToDataTable(this ExcelWorksheet ws, bool hasHeaderRow = true)
            {
                var tbl = new DataTable();
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column]) tbl.Columns.Add(hasHeaderRow ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                var startRow = hasHeaderRow ? 2 : 1;
                for (var rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    var row = tbl.NewRow();
                    foreach (var cell in wsRow) row[cell.Start.Column - 1] = cell.Text;
                    tbl.Rows.Add(row);
                }
                return tbl;
            }
