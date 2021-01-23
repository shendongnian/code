    DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
    column.Items.Add("0");
    column.Items.Add("1");
    column.Items.Add("2");
    dataGridView1.Columns.Add(column);
    
    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            }
        }
    
    void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = ((ComboBox)sender).SelectedIndex;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            if (selectedIndex == 0)
            { 
                style.BackColor = Color.AliceBlue;
            }
            if (selectedIndex == 1)
            {
                style.BackColor = Color.Beige;
            }
            if (selectedIndex == 2)
            {
                style.BackColor = Color.Crimson;
            }
            dataGridView1.CurrentCell.OwningRow.DefaultCellStyle = style;
            dataGridView1.Refresh();
        }
