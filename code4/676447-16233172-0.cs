    int texWidth = this._rWidth * Region.REGION_DIM * 16;
    int texHeight = this._rHeight * Region.REGION_DIM * 16;
    _renderTarget = new RenderTarget2D(GraphicsDevice, texWidth, texHeight);
    GraphicsDevice.SetRenderTarget(_renderTarget);
    GraphicsDevice.Clear(Color.Transparent);
    _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque);
    
    for (int blockX = 0; blockX < texWidth / 16; blockX++)
    {
        for (int blockY = 0; blockY < texHeight / 16; blockY++)
        {
             _spriteBatch.Draw(
                TextureManager.GetTextureAtIndex(b.GetIndexBasedOnMetadata(b.GetMetadataForSurroundings(this, blockX, blockY)), b.GetTextureFile()), 
             new Rectangle(blockX * 16, blockY * 16, 16, 16), 
             Color.White);
         }
    }
    
    _spriteBatch.End()
    
    GraphicsDevice.SetRenderTarget(null);
    var picture = _renderTarget;
