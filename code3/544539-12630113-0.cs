          /// <summary>
            /// Gets the Excel column name based on a supplied index number.
            /// </summary>
            /// <returns>1 = A, 2 = B... 27 = AA, etc.</returns>
            private string getColumnName(int columnIndex)
            {
                int dividend = columnIndex;
                string columnName = String.Empty;
                int modifier;
    
                while (dividend > 0)
                {
                    modifier = (dividend - 1) % 26;
                    columnName =
                        Convert.ToChar(65 + modifier).ToString() + columnName;
                    dividend = (int)((dividend - modifier) / 26);
                }
    
                return columnName;
            }
            private Cell createTextCell(int columnIndex, int rowIndex,  object cellValue)
            {
                Cell cell = new Cell();
    
                cell.DataType = CellValues.InlineString;
                cell.CellReference = getColumnName(columnIndex) + rowIndex;
    
                InlineString inlineString = new InlineString();
                Text t = new Text();
    
                t.Text = cellValue.ToString();
                inlineString.AppendChild(t);
                cell.AppendChild(inlineString);
    
                return cell;
            }
    
            public void ProcessDCTRows(IEnumerable<Row> dataRows, SharedStringTable sharedString)
            {
                try
                {
                    //Extract the information for each row 
                    foreach (Row row in dataRows)
                    {
                        IEnumerable<String> cellValues;
                        if (row.Descendants<Cell>().Count<Cell>() < 234)
                        {
                            int lastcolindex = row.Descendants<Cell>().Count<Cell>(); 
                            int rowindex = Convert.ToInt32(row.RowIndex.ToString());
                            int currentcount = 234 ;
                            for (; lastcolindex < currentcount; lastcolindex++)
                            {
                                row.AppendChild( createTextCell(lastcolindex,rowindex," " ));
                            }
    
                        }
    
    .   . //add processing code here
    
    }
