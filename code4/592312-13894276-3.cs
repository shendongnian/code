    //...
    protected override void Initialize( ) {
       // TODO: Add your initialization logic here
       square = new Texture2D( GraphicsDevice, 100, 100 );
       square.CreateBorder( 5, Color.Red );
       base.Initialize( );
    }
        
    //...
    protected override void Draw( GameTime gameTime ) {
       GraphicsDevice.Clear( Color.CornflowerBlue );
       // TODO: Add your drawing code here
       spriteBatch.Begin( );
       spriteBatch.Draw( square, new Vector2( 0.0f, 0.0f ), Color.White );
       spriteBatch.End( );
       base.Draw( gameTime );
    }
