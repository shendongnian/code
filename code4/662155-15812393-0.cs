        private ComboBox _chashedComboBox;
    
        private void dataGridView1_EditingControlShowing()
        {
           _chashedComboBox = (ComboBox)e.Control;
        }
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
                cmb = _chashedComboBox;
                if(cmb != null)
                {
                  cmb.DataSource = ds.Tables[0];
                  cmb.DisplayMember = "Grd";
                  cmb.ValueMember = "ID";
            
                  if(cmb.Items.Count > 0) 
                    cmb.SelectedIndex = 0;
                 }
        }
