    DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
    cmb.HeaderText = "-Select Data-";
    cmb.Name = "cmb";
    cmb.MaxDropDownItems = 4;
    cmb.Items.Add(txtName.Text);
    dataGridView1.Columns.Add(cmb);
