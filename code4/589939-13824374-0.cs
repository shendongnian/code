    private void dgTest_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
            {
                if (dgTest.CurrentCell.ColumnIndex == 0) // Which column ever is your DataGridComboBoxColumn
                {
                    // This line will enable you to use the DataDridViewCOmboBox like your
                    // Custom ComboBox.
                    CustomComboBox combo = e.Control as CUstomComboBox;
 
                }
            }
