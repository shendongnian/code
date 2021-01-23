        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            var hitTest = dataGridView1.HitTest(e.X, e.Y);
            string colDragged = dataGridView1.Columns[hitTest.ColumnIndex].Name;
            MessageBox.Show("Column Dragged is " + colDragged.ToString());
        }
