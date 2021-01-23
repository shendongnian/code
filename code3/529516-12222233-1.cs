    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (e.Control is DataGridViewComboBoxEditingControl)
        {
            ComboBox combo = (ComboBox)e.Control;
            ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
            ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
            combo.Validated -= new EventHandler(combo_Validated);
            combo.Validated += new EventHandler(combo_Validated);
        }
    }
    public static object GetPropValue(object src, string propName)
    {
        if (src == null)
            return null;
        return src.GetType().GetProperty(propName).GetValue(src, null);
    }
    void combo_Validated(object sender, EventArgs e)
    {
        Object selectedItem = ((ComboBox)sender).SelectedItem;
        DataGridViewComboBoxColumn col = (DataGridViewComboBoxColumn)dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex];
        if (!String.IsNullOrEmpty(col.ValueMember))
            dataGridView1.CurrentCell.Value = GetPropValue(selectedItem, col.ValueMember);
        else
           dataGridView1.CurrentCell.Value = selectedItem;
    }
