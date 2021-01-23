    void DateGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {            
        System.Windows.Forms.ComboBox comboBox = dataGridView.EditingControl as System.Windows.Forms.ComboBox;
        if (comboBox != null)
        {
            comboBox.DropDownClosed += comboBox_DropDownClosed;
        }
    }
    
    void comboBox_DropDownClosed(object sender, EventArgs e)
    {
        (sender as System.Windows.Forms.ComboBox).DropDownClosed -= comboBox_DropDownClosed;
        (sender as System.Windows.Forms.ComboBox).Parent.Focus();
    }
