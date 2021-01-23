        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            int hitTest = dataGridView1.HitTest(e.X, e.Y).ColumnIndex;
            string colDragged = dataGridView1.Columns[hitTest].Name;
            MessageBox.Show("Column Dragged is " + colDragged.ToString());
        }
