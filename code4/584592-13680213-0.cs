      List<dynamic> campaigns = new List<dynamic>();
      for (int i = 0; i < C; i++)
      {
        campaigns.Add(new {
          weekYear = "a", 
          campaign = "b", 
          totalBids = "c", 
          highestBid = "d", 
        });
      }
      dynamic[]  list = campaigns.ToArray();
