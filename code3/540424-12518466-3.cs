    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox1.Checked == true)
        {
            TextBox.UseSystemPasswordChar = true;
        }
        else 
        {
            TextBox.UseSystemPasswordChar = false;
        }
    }
