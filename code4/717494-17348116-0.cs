    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if(e.Control is DataGridViewComboBoxEditingControl){
            ((DataGridViewComboBoxEditingControl)e.Control).SelectedIndexChanged -= SelectedIndexChanged;
            ((DataGridViewComboBoxEditingControl)e.Control).SelectedIndexChanged += SelectedIndexChanged;
            }
        }
    private void SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewComboBoxEditingControl combo = sender as DataGridViewComboBoxEditingControl;
            //Change the source of the other combobox column accordingly
            //
            //////////////////////////////////////////////////////////
        }
