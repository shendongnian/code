    var armourInventory = new List<Armour>();
    foreach (Armour item in armousOnMap)
    {
        if ((item.Row != null && item.Row == _yPosition) && (item.Column != null && item.Column == _xPosition))
        {                    
            armourInventory.Add((Armour)item);
        }
    }
