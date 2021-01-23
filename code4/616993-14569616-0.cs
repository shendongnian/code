    for (int y = 0; y < ROWS; y++)
    {
        for (int x = 0; x < COLS; x++)
        {
            Tile t = new Tile()
            {
                Texture = tile,
                Position = new Microsoft.Xna.Framework.Point(x, y),
                Troops = rnd.Next(1, 4),
                OwnedByPlayerIndex = 0
            };
            t.Tap += tile_Tap;
            tiles.Add(t);
        }
    }
