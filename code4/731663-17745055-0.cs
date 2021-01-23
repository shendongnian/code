    private void radio_checked(object sender, EventArgs e)
    {
        if((sender as RadioButton).Checked)
        {
        RadioButton btn = (RadioButton)sender;
        Console.WriteLine("{0} Radio checked!", btn.Text);
        }
    }
