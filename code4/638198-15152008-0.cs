    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            {
                var value = (((DataGridView) (sender)).CurrentCell).Value;
                if (value != null)
                {
                    var txt = value.ToString();
                    double result;
                    double.TryParse(txt, out result);
                    if (result == 0)
                    {
                        (((DataGridView)(sender)).CurrentCell).Value = 0;
                        MessageBox.Show("Invalid input.");
                    }
                }
            }
