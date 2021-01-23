    foreach(var tile in TilesToCheck)
    {
        if(db.TileSet.Any(x => x.Col == tile.Col && x.Row == tile.Row))
        {
          // TODO: break the Save operation or whatever...
        }
    }
