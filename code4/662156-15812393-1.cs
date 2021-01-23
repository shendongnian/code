        private ComboBox _chashedComboBox;
    
        private void dataGridView1_EditingControlShowing()
        {
           _chashedComboBox = e.Control as ComboBox;
        }
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
                var cmb = _chashedComboBox;
                if(cmb != null)
                {
                  cmb.DataSource = ds.Tables[0];
                  cmb.DisplayMember = "Grd";
                  cmb.ValueMember = "ID";
            
                  if(cmb.Items.Count > 0) 
                    cmb.SelectedIndex = 0;
                 }
        }
