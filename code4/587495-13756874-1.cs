    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
            {
                ComboBox nameComboBox = e.Control as ComboBox;
                if (dataGridView1.CurrentCell.ColumnIndex == 0)
                {
                    if (nameComboBox != null)
                    {
                        ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                        ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                        ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
                    nameComboBox .SelectedIndexChanged -= (nameComboBox _SelectedIndexChanged);
                    nameComboBox .SelectedIndexChanged += (nameComboBox _SelectedIndexChanged);
                    }
                }
            }
        private void nameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 1)
            {
            var rowindex = dataGridView1.CurrentCell.RowIndex;
                  if (dataGridView1[1, rowindex].EditedFormattedValue != null)
                  {
                      Consol.WriteLine(dataGridView1[1, rowindex].EditedFormattedValue.ToString());
                  }
                  else
                  {
                     //No value in cell
                  }
            }
        }
    
         
