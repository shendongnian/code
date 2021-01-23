    private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
            {
                try
                {
                    ComboBox cb = (ComboBox)sender;
                    string check1 = cb.Text;
                    MessageBox.Show("Messagebox check");
                    string check2 = cb.Text;
                    MessageBox.Show(check1 + "\n\n" + check2);
                    //check 1 and 2 show the old value.  Once the method leaves then the value in the combobox is updated.
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
