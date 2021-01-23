    ///<summary> Instantiate the DataGridView Control. </summary>
    private DataGridView dgView = new DataGridView;
    
    ///<summary> Method to configure DataGridView Control. </summary>
    private void DataGridView_Configuration()
    {
        // In this case the method just contains the VisibleChanged event subscription.
    
        dgView.VisibleChanged += DgView_VisibleChanged;
    
        // Uncomment line bellow in case you want to keep the style when creating new rows.
        // dgView.RowsAdded += DgView_RowsAdded;
    }
    
    ///<summary> The actual Method that will re-design (Paint) DataGridView Cells. </summary>
     private void DataGridView_PaintCells()
     {
         int nrRows = dgView.Rows.Count;
         int nrColumns = dgView.Columns.Count;
         Color green = Color.LimeGreen;
    
         // Iterate over the total number of Rows
         for (int row = 0; row < nrRows; row++)
         {
             // Iterate over the total number of Columns
             for (int col = 0; col < nrColumns; col++) 
             {
                 // Paint cell location (column, row)
                 dgView[col, row].Style.BackColor = green;
             }
         }
     }
    
    ///<summary> The DataGridView VisibleChanged Event. </summary>
    private void DgView_VisibleChanged(object sender, EventArgs e)
    {
        DataGridView_PaintCells();
    }
    
    /// <summary> Occurrs when a new Row is Created. </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DgView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    { 
        DataGridView_PaintCells(); 
    }
