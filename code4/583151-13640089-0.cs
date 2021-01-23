    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    this.textBox1.TextChanged += new System.EventHandler(passwordChanged);
    this.textBox2.TextChanged += new System.EventHandler(passwordChanged);
    private void passwordChanged(object sender, EventArgs e)
    {
        String newPassword1 = textBox1.Text;
        String newPassword2 = textBox2.Text;
        if (!newPassword1.Equals(newPassword2))
        {
            textBox1.BackColor = Color.Red;
            textBox2.BackColor = Color.Red;
        }
        else
        {
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
        }
    }
