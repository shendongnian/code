     private void dataGridViewTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((System.Windows.Forms.DataGridViewTextBoxEditingControl)  
             (sender)).EditingControlDataGridView.CurrentCell.ColumnIndex.ToString() ==  
             "1")//Enter your column index
            {
                if (!char.IsControl(e.KeyChar)
                      && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                    MessageBox.Show("Enter only Numeric Values");
                    
                }
                else
                {
                  //  MessageBox.Show("Enter only Numeric Values");
                    e.Handled = true;
                }
            }
        }
