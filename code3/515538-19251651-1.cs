    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBoxImage.Checked)
        {
            groupBoxImage.Show();
        }
        else if (!checkBoxImage.Checked)
        {
            groupBoxImage.Hide(); 
        }
    }
