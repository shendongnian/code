    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
          {
              var selecetedEmployee = comboBox1.SelectedItem as Employee;
              if (selecetedEmployee == null)
              {
                   EmployeeForm nf = new EmployeeForm();
                   DialogResult res = nf.ShowDialog();
                   if (res == DialogResult.OK)
                   {
                       comboBox1.Items.Clear();
                       fillComboBox();
                   }
               }
               else
               {
                    textBox1.Text = selecetedEmployee.EmployeeID.ToString();
               }
          }
