    var ToBeDeleted = new List<player>(); //Or whatever type was the list players holding
    
    if (players.ContainsKey(coords[0])) {
                ToBeDeleted.Add(coords[0]);
            }
        
    foreach(var item in ToBeDeleted)
    {
    players.Remove(item);
    }
