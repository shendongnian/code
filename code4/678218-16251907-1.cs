    private void button1_Click(object sender, EventArgs e)
    {
        if (!checkBox1.Checked)
            MessageBox.Show("The box is not checked!");
        else
           label1.BackColor = (label1.BackColor == Color.Red ? Color.Blue : Color.Red);
    }
