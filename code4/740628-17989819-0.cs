        public void AddHeaders(DataGridView dataGridView)
     {
        for (int i = 0; i < 4; i++)
        {
            // Create a ComboBox which will be host a column's cell
            DataGridViewComboBoxCell comboBoxHeaderCell = new DataGridViewComboBoxCell();           
            comboBoxHeaderCell.Visible = true;
            foreach (KeyValuePair<string, string> label in _labels)
            {
                comboBoxHeaderCell.Items.Add(label.Key);
            }
            // Add the ComboBox to the header cell of the column
            dataGridView[i, 0] = comboBoxHeaderCell;
            comboBoxHeaderCell.Size = dataGridView.Columns[0].HeaderCell.Size;
            comboBoxHeaderCell.Text = _labels[i].Key;
        }
    }
