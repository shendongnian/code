    private void uxRadioButton_CheckedChanged(object sender, EventArgs e) 
    { 
         radioButtonCode(sender);
    }
    public void radioButtonCode(RadioButton myRadio)
    {
        if (myRadio.Checked == true)
        {
            int guySelected = getGuySelectedIndex(myRadio);
            uxPersonBettingLabel.Text = Guys[guySelected].Name;
            uxBetNumericUpDown.Maximum = Guys[guySelected].Cash;
        }
    }
    public int getGuySelectedIndex(RadioButton myRadio)
    {
        int index = 0;
        if (myRadio == this.uxRajRadioButton) index = 0;
        else if (myRadio == this.uxPaulRadioButton) index = 1;
        else if (myRadio == this.uxMikeRadioButton) index = 2;
        return index;
    }
