    var q = (from a in Auctions
             from g in (Auctions.Select(aa=>aa.GroupId).Distinct())
             orderby g, a.Date, a.Hour
             select new Auction
                 {
                      GroupId = g,
                      Date = a.Date,
                      Hour = a.Hour,
                      Offer      = a.GroupId == g ? a.Offer : 0,
                      Bid        = a.GroupId == g ? a.Bid : 0,
                      OfferPrice = a.GroupId == g ? a.OfferPrice : 0,
                      BidPrice   = a.GroupId == g ? a.BidPrice : 0
                  }
