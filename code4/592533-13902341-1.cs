    private void dataGridView1_MouseDown(object sender, MouseEventArgs e) {
        if (e.Button == MouseButtons.Right) {
            var ht = dataGridView1.HitTest(e.X, e.Y);
            // Place your condition HERE !!!
            // Currently it allow right click on last column only
            if ((    ht.ColumnIndex == dataGridView1.Columns.Count - 1) 
                 && (ht.Type == DataGridViewHitTestType.ColumnHeader)) {
                // This positions the menu at the mouse's location
                contextMenuStrip1.Show(MousePosition);
            }
        }
    }
