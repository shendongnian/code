    private void RadioButton_Checked(oject sender, EventArgs e)
    {
        RadioButton radio = ((RadioButton)sender);
        if(radio.Checked)
            groupBoxList.Tag = radio.Tag;
    }
 
