    private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
    {
        var hitTest = this.dataGridView1.HitTest(e.X, e.Y);
        if (hitTest.Type == DataGridViewHitTestType.Cell && hitTest.ColumnIndex == 0 /* set correct column index */)
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            { 
                // Toggle
                row.Cells[0].Value = !((bool)row.Cells[0].Value);
            }
        }
    }
