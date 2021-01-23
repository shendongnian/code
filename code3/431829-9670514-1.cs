    protected void ARadioButton_CheckedChanged(object sender, EventArgs e)
    {
        if (sender is RadioButton)
        {
           RadioButton radioButton = (RadioButton)sender;
           if (radioButton.Checked)
           {
               label.Text = ARadioButton.Text;
           }
    }
