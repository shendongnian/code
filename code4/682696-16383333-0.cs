    private void OnTimerTick(object sender, EventArgs e)
    {
        double milliV = Convert.ToDouble(textBox8.Text); //I have a value of 1.111
        Termocoppia thm = new Termocoppia();
        // the return value from Cacola has to be assigned to tempEx
        tempEx = thm.Calcola(milliV, tempEx);
        textBox7.Text = tempEx.ToString();
    }
