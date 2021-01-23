       private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
            {
                double value = 0;
                if (double.TryParse(e.FormattedValue.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out value))
                {
                    dataGridView1[e.ColumnIndex, e.RowIndex].ErrorText = "";
                   
    
                    //   e.Cancel = false;
                }
                else
                {
                    dataGridView1[e.ColumnIndex, e.RowIndex].ErrorText = "Bad Input Please Correct It !";
                    //   e.Cancel = true;  if you do this the datagrid dont let user go next row
                }
            }
