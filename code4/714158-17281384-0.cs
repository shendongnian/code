    public void Draw(Camera camera, GraphicsDevice device, SpriteBatch spriteBatch, Texture2D Texture)
    {
         Vector3 pos1= device.Viewport.Project(
              this.position, 
              camera.Projection, camera.View, camera.World);
         Vector3 pos2= device.Viewport.Project(
              this.position+ Vactor3.UnitY*10, 
              camera.Projection, camera.View, camera.World);
         Vector2 pos = new Vector2(pos1.X, pos1.Y);
         Vector2 origin = new Vector2(Texture.Bounds.Center.X, Texture.Bounds.Center.Y);
         float Scale = Vector3.Distance(pos1, pos2) * CustomRatio;
  
         spriteBatch.Begin();
         spriteBatch.Draw(Texture, pos, null, Color.White, 0, 
                          origin, Scale, SpriteEffects.None, 0);
         spriteBatch.End();
    
        device.RasterizerState = RasterizerState.CullCounterClockwise;
        device.BlendState = BlendState.Opaque;
        device.DepthStencilState = DepthStencilState.Default;
    }
