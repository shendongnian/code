    //Load basic texture to make it recognizable :)
    sprite= Content.Load<Texture2D>("spritetexture");
    //Default position in middle
    spritePosition = new Vector2(
                        (graphics.GraphicsDevice.Viewport.Width / 2) - (sprite.Width / 2),
                        (graphics.GraphicsDevice.Viewport.Height / 2) - (sprite.Height / 2));
    //Sprite centering
    spriteOriginalPos.X = sprite.Width / 2;
    spriteOriginalPos.Y = sprite.Height / 2;
