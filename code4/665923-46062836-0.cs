    private void MyDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        var cellUnderConsideration = dgvVendors.Rows[e.RowIndex].Cells[e.ColumnIndex];
            
        if (!ValidateCurrentCellValue(cellUnderConsideration)) 
        {               
           OnNotification( String.Format( "Comment `{0}` contains invalid characters) );
           //Or MessageBox.Show("your custom message");
    
           isInvalidState = true;
           cellWithInvalidUserInput = cellUnderConsideration;
           e.Cancel = true;                    
        }
    }
