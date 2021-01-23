     private void DoSomething()
     {
          if (bidder00.Text == addbidder1.Text)
          {
              ...
          }
     }
     private void Timer1_OnTick(object sender, EventArgs e)
     {
         DoSomething();
     }
     private void bidder00_TextChanged(object sender, EventArgs e)
     {
         DoSomething();
     }
