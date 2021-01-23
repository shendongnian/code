        private void Form1_Load(object sender, EventArgs e)
        {
            // Add a handler for the cell value changed event:
            this.myDataGridView.CellValueChanged += new DataGridViewCellEventHandler(myDataGridView_CellValueChanged);
        }
        void myDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // grab a reference to the changed cell:
            DataGridViewCell cell = myDataGridView.Rows[e.RowIndex].Cells["contract_id"];
            // Guard against the case where this is the first row in the DGV table:
            if (cell.RowIndex - 1 >= 0)
            {
                if (cell.Value != myDataGridView.Rows[cell.RowIndex - 1].Cells["contract_id"].Value)
                {
                    // CHange the Style.BackColor property for the cell:
                    myDataGridView.CurrentRow.Cells["contract_id"].Style.BackColor = Color.Blue;
                }
            }
