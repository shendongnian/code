    private void button1_Click(object sender, EventArgs e)
    {
         if (!Directory.Exists(this.textBox1.Text.Trim()))
            {
                Directory.CreateDirectory(this.textBox1.Text.Trim());
            }
    }
