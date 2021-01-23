    /// <summary> Centre Columns Headers. </summary>
    private void DataGridView_CentreHeaders()
    {
        // Centre Column Cells Content
        dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
    
        // Centre (Column and Row) Headers    
        dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        
        // Set Font
        dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
    }
