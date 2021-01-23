        private void dataGridView1_CellValidating(object sender, 
                                               DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1) // 1 should be your column index
            {
                int i;
                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    label1.Text ="please enter numeric";
                }
                else
                {
                    // the input is numeric 
                }
            }
        }
