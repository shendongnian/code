      private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
            {
                if (dataGridView1[e.ColumnIndex, e.RowIndex].Value == null)
                    return;
                  double value = 0;
                  if (double.TryParse(dataGridView1[e.ColumnIndex,e.RowIndex].Value.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out value))
                  {
                      dataGridView1[e.ColumnIndex, e.RowIndex].Value = Math.Round(value, 2).ToString().Replace("/",".");
                  }
            }
