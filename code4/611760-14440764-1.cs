    private void SubmitBid()
    {
        // code you want to execute
    }
    private void OnSubmitBid()
    {
         // confirm whether we can actually submit the bid
         if (bidder00.Text == addbidder1.Text)
         {
              SubmitBid();
         }
    }
    private void Timer1_OnTick(object sender, EventArgs e)
    {
        // trigger code from timer
        OnSubmitBid();
    }
    private void bidder00_TextChanged(object sender, EventArgs e)
    {
        // trigger code from text change
        OnSubmitBid();
    }
    private void btnBid_Click(object sender, EventArgs e)
    {
        // trigger code from button press
        OnSubmitBid();
    }
