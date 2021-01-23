    private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
            {
                if (dataGridView1.IsCurrentCellDirty)
                    if (e.ColumnIndex == 0)
                    {
                        if (int.Parse(dataGridView1[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString()) != 100)
                        {
                            e.Cancel = true;
                            MessageBox.Show("The inputed is not 100%. Please check. Press Esc to cancel change.");
                        }
                        else
                        {
                            //Successcully entered
                        }
                    }
            }
