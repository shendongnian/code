    var topItmes = new List<ChallengeList>();
    var otherItmes = new List<ChallengeList>();
    
    foreach (var item in challenge)
    {
        if(/*item needs to be on top*/)
        {
    		topItmes.Add(item);
        }
        else
        {
            otherItmes.Add(item);
        }
    }
    
    topItmes.AddRange(otherItmes);
