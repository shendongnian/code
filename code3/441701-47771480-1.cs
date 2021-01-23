        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == excelDataGridView.Columns["Links"].Index) //Handling of HyperLink Click
            {
                string cellValue = excelDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                Process.Start(cellValue); //assumes the link points to the text file and opens it in the default text editor
            }
        }
