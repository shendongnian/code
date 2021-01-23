     private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridViewRow clickedRow = (sender as DataGridView).Rows[e.RowIndex]; 
                    if (!clickedRow.Selected)
                        dataGridView1.CurrentCell = clickedRow.Cells[e.ColumnIndex];
                    var mousePosition = dataGridView1.PointToClient(Cursor.Position);
                    
                    ContextMenu1.Show(dataGridView1, mousePosition);
                }
            }
