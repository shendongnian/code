    public void DoMouseClick(Vector2 pMouseXY)
    {
       ...
       Vector2 tileXY = ScreenToTile(pMouseXY);
       
       mSelectedTileCoordinate = tileXY;
    }
