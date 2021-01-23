        private void form_Shown(object sender, EventArgs e)
        {
                foreach (DataGridViewColumn c in dataGridView.Columns)
                    c.Width = c.GetPreferredWidth(DataGridViewAutoSizeColumnMode.DisplayedCells, true);
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }
 
