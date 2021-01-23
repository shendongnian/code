    List<WhateverYourCollectionWasOf> statsToDelete;
    foreach(var s in AllSnapShots)
    {
        statsToDelete.AddRange(s.Stats.Where(stat => stat.Model.Agent == null));
        foreach (var stat in statsToDelete)
        {
             s.Stats.Remove(stat);
        }
    }
