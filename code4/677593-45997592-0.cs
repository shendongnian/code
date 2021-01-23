        private void DataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up) || e.KeyCode.Equals(Keys.Down))
            {
                MoveUpDown(e.KeyCode == Keys.Up);
            }
            e.Handled = true;
        }
        private void MoveUpDown(bool goUp)
        {
            try
            {
                int currentRowindex = DataGridView.SelectedCells[0].OwningRow.Index;
                int newRowIndex = currentRowindex + (goUp ? -1 : 1);
                if (newRowIndex > -1 && newRowIndex < DataGridView.Rows.Count)
                {
                    DataGridView.ClearSelection();
                    DataGridView.Rows[newRowIndex].Selected = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }
