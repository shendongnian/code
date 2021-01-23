    Random _Random = new Random();
    private int MaxX;
    private int MaxY; //screen height and width 
    
    public Texture2D hat;
    
    //code to load in image
    
    // make sure x and y are initialized only once before rendering loop
    int x = _Random.Next(1, MaxX);
    int y = _Random.Next(1, MaxY);
    
    //draw code
    spriteBatch.Begin();
     int hatx = x;
     int haty = y;
    
     spriteBatch.Draw(hat, new Rectangle(hatx, haty, 80, 80), Color.White);
     spriteBatch.End();
