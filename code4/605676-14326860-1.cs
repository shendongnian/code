    public override void DetachEditingControl()
        {
            DataGridView dataGridView = this.DataGridView;
            if (dataGridView == null || dataGridView.EditingControl == null)
            {
                throw new InvalidOperationException("Cell is detached or its grid has no editing control.");
            }
            DataGridViewCheckBoxComboBoxCellEditingControl ctl = DataGridView.EditingControl as DataGridViewCheckBoxComboBoxCellEditingControl;
            if (ctl != null)
            {
                ctl.CheckBoxItems.Clear();  //Forgot to do this.
                ctl.EditingControlFormattedValue = String.Empty;
            }
            base.DetachEditingControl();
        }
