    public void paintFareTableCells(DataTable fareTable)
    {
        fareDataGrid.DataSource = fareTable;
    }
    void fareDataGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        for (rowIndex = 0; rowIndex < 26; rowIndex++)
        {
            for (colIndex = 0; colIndex < 3; colIndex++)
            {
                switch (fareTable.Rows[rowIndex][colIndex + 3].ToString())   //Check the color index columns 3-5
                {
                    case "low":
                        fareDataGrid[colIndex, rowIndex].Style.BackColor = Color.Green;
                        break;
                    case "med":
                        fareDataGrid[colIndex, rowIndex].Style.BackColor = Color.Yellow;
                        break;
                    case "high":
                        fareDataGrid[colIndex, rowIndex].Style.BackColor = Color.Red;
                        break;
                    default:
                        break;
                }
                // Diagnostics: Check cell's color. At this point, Colors are OK!  
                Color color = fareDataGrid[colIndex, rowIndex].Style.BackColor;
            }
        }
    }
