       private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
       {
           if(Convert.ToInt32(comboBox1.SelectedValue.ToString())==-1)
           {
            EmployeeForm nf = new EmployeeForm();
            DialogResult res = nf.ShowDialog();
            if (res == DialogResult.OK)
            {
                comboBox1.Items.Clear();
                fillComboBox();
            }
           }
        }
