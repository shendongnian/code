    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
            if (checkBox1.Checked == true)
                comboBox2.Visible = true;
            if (checkBox1.Checked == false)
                comboBox2.Visible = false;
