    Texture2D pixel;
    public override void LoadContent()
    {
    pixel = new Texture2D(this.GraphicsDevice,1,1);
    Color[] colourData = new Color[1];
    colourData[0] = Color.White; //The Colour of the rectangle
    pixel.SetData<Color>(colourData);
    
    }
    
    public void DrawRectangle(SpriteBatch spriteBatch, Rectangle bounds)
    {
    spriteBatch.Draw(pixel,bounds,Color.White);
    }
