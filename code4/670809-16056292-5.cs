    private void AddButton_Click(object sender, EventArgs e)
    {
        Player thePlayer = new Player(int.Parse(StrBox.Text), int.Parse(SPBox.Text));
        if (thePlayer.GainStrength())
        {
            StrBox.Text = thePlayer.Strength.ToString();
            SPBox.Text = thePlayer.StatPoints.ToString();
        }
        else
        {
            MessageBox.Show("Earn more experience!");
        }
    }
