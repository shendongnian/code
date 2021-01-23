    private void button1_Click(object sender, EventArgs e)
    {
        string username1 = "Richard";
        string password1 = "Peugeot";
        if (this.textBox1.Text == username1 && this.textBox2.Text == password1)
        {
            MessageBox.Show("Welcome Richard!", "Welcome");
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        else
        {
            MessageBox.Show("Incorrect username or password", "Bad credentials");
            DialogResult = System.Windows.Forms.DialogResult.No;
        }
    }
