        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty) //or IsCurrentRowDirty
            {
                if (e.ColumnIndex == 1)
                {
                    if (MessageBox.Show("You're about to change the value. Do you want to continue?\n\nPress ESC to cancel change.",
                                        "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information) != System.Windows.Forms.DialogResult.OK)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }
