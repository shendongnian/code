       private void employeesDataGridView_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo;
            if (e.Button == MouseButtons.Right)
            {
                hitTestInfo = employeesDataGridView.HitTest(e.X, e.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.RowHeader || hitTestInfo.Type == DataGridViewHitTestType.Cell)
                {
                    if (hitTestInfo.ColumnIndex != -1)
                        employeesDataGridView.CurrentCell = employeesDataGridView[hitTestInfo.ColumnIndex, hitTestInfo.RowIndex];
                    contextMenuStrip1.Show(employeesDataGridView, employeesDataGridView.PointToClient(System.Windows.Forms.Cursor.Position));
                }
            }       
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employeesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            var current = employeesDataGridView.CurrentCell;
            if (current == null) return;
            if (current.ColumnIndex == -1)
                return;
            if (current.RowIndex == -1)
                return;
            employeesDataGridView[current.ColumnIndex, current.RowIndex].Selected = true;
        }
