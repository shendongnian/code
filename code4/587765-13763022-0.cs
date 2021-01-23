    public void TimerTick(object sender, EventArgs e)
    {
         var player = Players[currentDealingID];
         Point pbsLocation = player.CardPBS[0].Location;
         MoveCard();
         
         if (IsCardArrivedTo(pbsLocation)) 
         {        
            MovingCard.Hide();
            T.Stop();
            giveRandomCardTo(player);
         }
    }
    private bool IsCardArrivedTo(Point location)
    {
        double epsilon = 20;
        return Distance(MovingCard.Location, location) < epsilon;
    }
    private void MoveCard()
    {
       // calculate new location
       MovingCard.Location = newLocation;
    }
