        private void DataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            //I use only one function for moving with the information
            //e.KeyCode == Keys.Up = move up, else move down
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
                //Here I decide to change the row with the parameter
                //True -1 or False +1
                int newRowIndex = currentRowindex + (goUp ? -1 : 1);
                //Here it must be ensured that we remain within the index of the DGV
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
