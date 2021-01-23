     DataRow row;
        for(int currentRow=0; currentRow < table.Rows.Count; currentRow++)
        {
             row = table.Rows[currentRow];
                for (int currentCol = 0; currentCol < table.Columns.Count; currentCol++ )
                {
                    if (table.Columns[currentCol].ColumnName == "product")
                    {
                        excelDoc.setCell(1, 1, currentRow, currentCol, row[currentCol - 1].ToString());
                    }
                }
                      
        }
