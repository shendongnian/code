    /// <summary> Centre Columns Headers. </summary>
    private void DataGridView_CentreHeaders()
    {
        // Centre Cell Content
        dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
    
        // Centre (Column and Row) Headers
        //dataGridView.EnableHeadersVisualStyles = false;
        //dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
    
        foreach (DataGridViewColumn col in dataGridView.Columns)
        {
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Font = new Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
        }
    }
