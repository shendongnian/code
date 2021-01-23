    private void radio_checked(object sender, EventArgs e)
    {
        RadioButton btn = (RadioButton)sender;
        if(btn.Checked)
            Console.WriteLine("{0} Radio checked!", btn.Text);
    }
