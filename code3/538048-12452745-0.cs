    foreach (DataGridViewColumn column in myDataGridView.Columns)
    {
       DataGridViewColumnHeaderCell headerCell = column.HeaderCell;
       string headerCaptionText = column.HeaderText;
       string columnName = column.Name; // Used as a key to myDataGridView.Columns['key_name'];
    }
