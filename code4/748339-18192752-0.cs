    TileRef[,] tiles;
    TileMapper(int xsize, int ysize)
    {
      tiles = new TileRef[xsize,ysize];
      for (int x=0; x < xsize; x++)
        for (int y=0; y < xsize; y++)
        {
          var thisRef = new TileRef();
          thisRef.X = x;
          thisRef.Y = y;
          thisRef.Width = 1;
          thisRef.Height = 1;
          thisRef.Tile = new Tile(); // Make a default tile instance somehow
          tiles[x][y] = thisRef;
        }
    }
    To join a bunch of squares together into a blob:
    public JoinSquares(int x, int y, int width, int height)
    {
          var thisRef = new TileRef();
          thisRef.X = x;
          thisRef.Y = y;
          thisRef.Width = 1;
          thisRef.Height = 1;
          thisRef.Tile = new Tile(); // Make a default tile instance somehow
          for (i=0; i<width; i++)
            for (j=0; j<height; j++)
              tiles[x+i,y+j] = thisRef;
    }
    public SeparateSquares(int x, int y)
    {
          var oldRef = tiles[x,y];
          x=oldref.X;
          y=oldref.Y;
          var width=oldref.Width;
          var height=oldref.Height;
     
          for (i=0; i<width; i++)
            for (j=0; j<height; j++)
            {
              var thisRef = new TileRef();
              thisRef.X = x+i;
              thisRef.Y = y+j;
              thisRef.Width = 1;
              thisRef.Height = 1;
              thisRef.Tile = new Tile(); // Make a default tile instance somehow
              tiles[x+i,y+j] = thisRef;
            }
    }
    To change the `Tile` associated with a "blob", simply
    public Tile this[int x, int y]
    {
        get 
        {
            return tiles[x,y].Tile;
        }
        set
        {
            tiles[x,y].Tile = value;
        }
    }
