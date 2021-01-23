    public void SetTile(Vector2 position, int tileId)
    {
        Tile oldTile = Map.GetTile(position);
    
        Tile newTile = new Tile(position, tileId);
    
        MapChange change = new MapChange(oldTile, newTile);
    
        //Only push to cahngestacks if successfull    
        if (change.PerformChange(Map))
        {
            ChangeStack.Push(change);
    
            //We don't want you to be able to "redo" anymore if you do something new.
            RedoStack.Clear();
        }
    }
    public void RemoveTile(Vector2 position)
    {
        Tile oldTile = Map.GetTile(position);
    
        Tile newTile = null;
    
        MapChange change = new MapChange(oldTile, newTile);
    
        //Only push to changestacks if successfull    
        if (change.PerformChange(Map))
        {
            ChangeStack.Push(change);
    
            //We don't want you to be able to "redo" anymore if you do something new.
            RedoStack.Clear();
        }
    }
