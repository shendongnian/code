    class dgvControl : DataGridView
    {
        // Keep track of the most recently selected column:
        private DataGridViewColumn _currentColumn;
        public dgvControl() : base()
        {
            this.EnableHeadersVisualStyles = false;
            // Add a handler for the cell enter event:
            this.CellEnter += new DataGridViewCellEventHandler(dgvControl_CellEnter);
            // When the Control is initialized, instantiate the placeholder
            // variable as a new object:
            _currentColumn = new DataGridViewColumn();
            // In case there are no columns added (for the designer):
            if (this.Columns.Count > 0)
            {
                this.OnColumnFocus(0);
            }
        }
        void dgvControl_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.OnColumnFocus(e.ColumnIndex);        
        }
        void OnColumnFocus(int ColumnIndex)
        {
            // If the new cell is in the same column, do nothing:
            if (ColumnIndex != _currentColumn.Index)
            {
                // Set up a custom font to represent the current column:
                Font selectedFont = new Font(this.Font, FontStyle.Bold);
                // Grab a reference to the current column:
                var newColumn = this.Columns[ColumnIndex];
                // Change the font to indicate status:
                newColumn.HeaderCell.Style.Font = selectedFont;
                // Change the color to a slightly darker shade of gray:
                newColumn.HeaderCell.Style.BackColor = Color.LightGray;
                // Set the font of the previous column back to normal:
                _currentColumn.HeaderCell.Style.Font = this.Font;
                // Change the color of the previous column back to the default:
                _currentColumn.HeaderCell.Style.BackColor = Color.Empty;
                // Set the current column placeholder to refer to the new column:
                _currentColumn = newColumn;
            }
        }
    }
