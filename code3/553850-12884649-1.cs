    Teams Rounds = new Teams(22);
    if (Rounds.DummyTeam) { 
           // Anything to do if nober of teams is odd?
    }
    Rounds.LogRound();    // DEBUG - you can check number of matches ;-)
    while (Rounds.NextRoundExists)     // While we have next round...
     {
       Rounds.NextRound();             // ... generate the next 
                                       //     round (team assignment)
       // Your can tack using: Rounds.GetCurrentRound()
     }
    // If you want to see the number of matches, call Rounds.GetCounters();
