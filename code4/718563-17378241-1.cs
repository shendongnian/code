     private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                    dataGridView1.DoDragDrop(
                       dataGridView1.Rows[e.RowIndex]
                                    .Cells[e.ColumnIndex]
                                    .Value.ToString(), 
                       DragDropEffects.Copy);
            }
    private void dataGridView1_DragDrop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(System.String)))
        {
            Point clientPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));
            int rowIndex = dataGridView1.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
            int colIndex = dataGridView1.HitTest(clientPoint.X, clientPoint.Y).ColumnIndex;
            if (rowIndex > -1 && colIndex > -1)
                dataGridView1.Rows[rowIndex].Cells[colIndex].Value =  
                               (System.String)e.Data.GetData(typeof(System.String));
        }
    }
