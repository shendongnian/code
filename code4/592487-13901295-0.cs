        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView2.IsCurrentCellDirty)
                if (e.ColumnIndex == 0)
                {
                    if (string.IsNullOrWhiteSpace(dataGridView2[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString()))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Please enter some text before you leave.");
                    }
                    else if (dataGridView2[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString() != "S")
                    {
                        e.Cancel = true;
                        MessageBox.Show("You have to enter S");
                    }
                }
        }
    }
