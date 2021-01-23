    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
       if (dataGridView1.CurrentCell.GetType() == typeof(DataGridViewCheckBoxCell)) 
       {
           DataGridViewCheckBoxCell chkbx = dataGridView1.CurrentCell as DataGridViewCheckBoxCell;
           if (Convert.ToBoolean(chkbx.Value)) MessageBox.Show("true");
           if (!Convert.ToBoolean(chkbx.Value)) MessageBox.Show("false");
       }
       else
       {
            if ((bool)dataGridView1.CurrentCell.Value == true) MessageBox.Show("true");
            if ((bool)dataGridView1.CurrentCell.Value == false) MessageBox.Show("false");
       }
       MessageBox.Show(dataGridView1.CurrentCell.Value.ToString());
    }
