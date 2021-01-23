    public void timer2_Tick(object sender, EventArgs e)
    {
        this.Width += 20;
        this.Height += 20;
        if (this.Height >= 400)
        {
            timer2.Enabled = false;
        }
    }
