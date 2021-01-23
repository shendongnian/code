    private void dgvMyDataGridView_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            var hitTestInfo = dgvMyDataGridView.HitTest(e.X, e.Y);
            if ((hitTestInfo.Type == DataGridViewHitTestType.Cell) &&
                (hitTestInfo.ColumnIndex == 1) &&
                (hitTestInfo.RowIndex >= 0))
            {
                string currentCell = dgvMyDataGridView.Rows[hitTestInfo.RowIndex].Cells[hitTestInfo.ColumnIndex].Value.ToString();
                ContextMenu m = new ContextMenu();
                dgvMyDataGridView.CurrentRow.Cells[0].Value.ToString();
                m.MenuItems.Add(new MenuItem("Click Me!", new EventHandler((itemSender, itemEvent) =>
                {
                    var result = MessageBox.Show("You've clicked " + currentCell + ". Open next form?", "Continue?", MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        // Code to open a new form page.
                    }
                })));
                m.Show(dgvMyDataGridView, new Point(e.X, e.Y));
            }
        }
    }
