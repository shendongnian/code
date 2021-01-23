     private void dataGridView1_CellValidating(object sender, 
                                           DataGridViewCellValidatingEventArgs e)
    {
        if (e.ColumnIndex == 1) // You can pass column index or column name
        {
            int i;
            if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
            {
                e.Cancel = true;
                
                MessageBox.show("Only Numeric values allowed");
            }
            else
            {
                // The value entered is numeric
            }
        }
    }
