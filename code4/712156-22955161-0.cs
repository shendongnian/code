        public void DataGridView_RightMouseDown_Select(object sender, MouseEventArgs e)
        {
            // If the user pressed something else than mouse right click, return
            if (e.Button != System.Windows.Forms.MouseButtons.Right) { return; }
            DataGridView dgv = (DataGridView)sender;
            // Use HitTest to resolve the row under the cursor
            int rowIndex = dgv.HitTest(e.X, e.Y).RowIndex;
            // If there was no DataGridViewRow under the cursor, return
            if (rowIndex == -1) { return; }
            // Clear all other selections before making a new selection
            dgv.ClearSelection();
            // Select the found DataGridViewRow
            dgv.Rows[rowIndex].Selected = true;
        }
