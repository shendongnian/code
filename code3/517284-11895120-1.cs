    private void timer1_Tick(object sender, EventArgs e)
    {
        if(this.BackColor == Color.Green)
                this.BackColor = Color.Yellow;
        else
                this.BackColor = Color.Green;
    }
