    private void timer1_Tick(object sender, EventArgs e)
    {
       Perform();
    }
        
    private void bidder00_TextChanged(object sender, EventArgs e)
    {
       Perform();
    }
        
    private void Perform()
    {
       if (bidder00.Text == addbidder1.Text)
       {
          bidBtn1.PerformClick();
       }
    }
