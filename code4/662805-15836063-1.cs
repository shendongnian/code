        private void DataGrid_AutoGeneratingColumn(
            object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "ID")
            {
                e.Cancel = true;
            }
        }
