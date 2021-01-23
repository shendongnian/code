    public void uxRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton myRadio = (RadioButton) sender;
        if (myRadio.Checked)
        {
            GuySelected = (int)myRadio.Tag;
            uxPersonBettingLabel.Text = Guys[GuySelected].Name;
            uxBetNumericUpDown.Maximum = Guys[GuySelected].Cash;
        }
    }
