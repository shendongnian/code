      private static Worksheet GetWorksheet(SpreadsheetDocument document, string worksheetName = "Sheet1")
        {
            var sheets = document.WorkbookPart.Workbook
                .Descendants<Sheet>().Where(s => s.Name == worksheetName);
            var worksheetPart = (WorksheetPart)document.WorkbookPart
                .GetPartById(sheets.First().Id);
            return worksheetPart.Worksheet;
        }
        private static string GetColumnName(int columnIndex)
        {
            var dividend = columnIndex;
            var columnName = String.Empty;
            while (dividend > 0)
            {
                var modifier = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modifier).AsString() + columnName;
                dividend = (dividend - modifier) / 26;
            }
            return columnName;
        }
        private static Cell CreateTextCell(int columnIndex, int rowIndex, object cellValue)
        {
            var cell = new Cell();
            var inlineString = new InlineString();
            var txt = new Text();
            cell.DataType = CellValues.InlineString;
            cell.CellReference = GetColumnName(columnIndex) + rowIndex;
            txt.Text = cellValue.AsString();
            inlineString.AppendChild(txt);
            cell.AppendChild(inlineString);
            return cell;
        }
        private static Row CreateContentRow(int rowIndex, object[] cellValues)
        {
            var row = new Row
            {
                RowIndex = (UInt32)rowIndex
            };
            for (var i = 0; i < cellValues.Length; i++)
            {
                var dataCell = CreateTextCell(i + 1, rowIndex, cellValues[i]);
                row.AppendChild(dataCell);
            }
            return row;
        }
