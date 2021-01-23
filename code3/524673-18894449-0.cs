    private void dataGridView1_EditingControlShowing(object sender,
    DataGridViewEditingControlShowingEventArgs e)
    {
    if (dataGridView1.CurrentCell.ColumnIndex == 0)
    {
    // Check box column
    ComboBox comboBox = e.Control as ComboBox;
    comboBox.SelectedIndexChanged += new EventHandler(comboBox_SelectedIndexChanged);
    }
    }
    void comboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
    int selectedIndex = ((ComboBox)sender).SelectedIndex;
    MessageBox.Show("Selected Index = " + selectedIndex);
    }
  
