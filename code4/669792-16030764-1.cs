    private void button1_Click(object sender, EventArgs e)
            {
                string username1 = "Richard";
                string password1 = "Peugeot";
    
                if (this.textBox1.Text == username1 && this.textBox2.Text == password1)
                 {
                    MessageBox.Show("Welcome Richard!", "Welcome");
                    Form1 frm = new Form1();
                    frm.Show();
                    this.Hide(); //If you want to hide the log in form after form1 has loaded
                 }
                else
                    MessageBox.Show("Incorrect username or password", "Bad credentials");
            }
