    public void timer2_Tick(object sender, EventArgs e)
    {
        
        if (this.Height < 400)
        {
            this.Height += 20;
            this.Width += 20;   
        }
        else
        {
            timer2.Enabled = false;
        }
    }
