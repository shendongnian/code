    public void textBox2_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            if (user == Username[1] && pass == passwords[1])
            {
                MessageBox.Show("Login successfull", "Welcome, HR");
                UpdateDBForm newEmployee = new UpdateDBForm();
                this.Hide();
                newEmployee.ShowDialog();
                return;        
            }
        }
    }
