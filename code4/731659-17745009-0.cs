    private void radio_checked(object sender, EventArgs e)
    {
        //Check if this is a radio button. It might be a checkbox!
        if(sender is RadioButton)
        {
            RadioButton btn = (RadioButton)sender;
            if(btn.Checked)
                Console.WriteLine("{0} Radio checked!", btn.Text);
        }
    }
