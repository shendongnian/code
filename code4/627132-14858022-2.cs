    // any changes related to the paymentAttempt object 
                    
    _auctionContext.Entry(paymentAttempt).State = EntityState.Modified;
      
    foreach (var winningBid in relevantWinningBidsTotalPrices)
    {
       winningBid.Locked = false;
       _auctionContext.UpdateObject(winningBid);
    }
         
    _auctionContext.SaveChanges();
