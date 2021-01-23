    private void button1_Click(object sender, EventArgs e)
    {
        var pattern = @"^[0-9]*(\.[0-9]{1,2})?$";
        if(Regex.IsMatch(textBox1.Text, pattern))
            MessageBox.Show("Correct Input.");
        else
            MessageBox.Show("Wrong Input!");
    }
