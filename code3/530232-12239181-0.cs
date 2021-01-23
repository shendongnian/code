        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string message = "You have clicked " + (e.ColumnIndex + 1).ToString() + " cell inside " + (e.RowIndex + 1).ToString() + " row!";
            MessageBox.Show(message, "Click info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
