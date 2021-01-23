        public event DataGridViewCellMouseEventHandler CellMouseClick;
    
        private void DataGridView1_CellMouseClick(Object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show("Mouse clicked in the datagridview!");
        }
