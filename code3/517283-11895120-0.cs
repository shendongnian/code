    private bool isYellow = true;
    private void timer1_Tick(object sender, EventArgs e)
    {
        if(isYellow)
        {
                this.BackColor = Color.Yellow;
                isYellow = false;
        }
        else
        {
                this.BackColor = Color.Green;
                isYellow = true;
        }
    }
