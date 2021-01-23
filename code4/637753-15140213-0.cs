    private void DGVWarehouse_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
                int colIndex = e.ColumnIndex;
                int rowIndex = e.RowIndex;
            if (colIndex == 0 && rowIndex >=0)
            {
                DataGridViewRow theRow = DGVWarehouse.Rows[rowIndex];
                if (theRow.Cells[colIndex].Value.ToString() != String.Empty || theRow.Cells[colIndex].Value.ToString() != null)
                {
                    if (theRow.Cells[colIndex].Value.ToString() == "YourArtID")
                    {
                        theRow.DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                    else if (theRow.Cells[colIndex].Value.ToString() == "YourArtID")
                    {
                        theRow.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                    else if (theRow.Cells[colIndex].Value.ToString() == "YourArtID")
                    {
                        
                        theRow.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                    else
                    { 
                        // Your DEFAULT STYLE
                    }
                }
            }
        }
