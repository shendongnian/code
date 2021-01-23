        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == -1) return;
            var cellRectangle = dataGridView1.PointToScreen(
                dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location);
            panel1.Location = new Point(cellRectangle.X + 50, cellRectangle.Y - 175);
            panel1.Show();
        }
