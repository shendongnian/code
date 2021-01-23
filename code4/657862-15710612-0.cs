     protected override void Draw( GameTime gameTime ) {
            GraphicsDevice.Clear( Color.CornflowerBlue );
            var ss = 3 * BLOCK_TOTAL_SIZE + BLOCK_GAP;
            var bounds = new Rectangle( S, S, ss, ss );                         // Triangle background
            spriteBatch.Begin( SpriteSortMode.Deferred, BlendState.Opaque );
            spriteBatch.Draw( white, bounds, BackColor );
            spriteBatch.End( );
            Matrix transform = Matrix.Identity;
            for (int i = 0; i < 4; i++) {
                // Player area by color
                spriteBatch.Begin( SpriteSortMode.Deferred, BlendState.Opaque, null, null, null, null, transform );
                DrawPlayerAreaByColor( colors[i] );
                spriteBatch.End( );
                transform = Matrix.CreateRotationZ( -MathHelper.PiOver2 ) * Matrix.CreateTranslation( 0, BLOCK_TOTAL_SIZE * 15 - BLOCK_GAP, 0 ) * transform; 
                // Triangle
                for (int j = 0; j < vertex.Length; j++) vertex[j].Color = colors[i];
                basicEffect.World = Matrix.CreateRotationZ( -i * MathHelper.PiOver2 ) * Matrix.CreateTranslation( bounds.Center.X, bounds.Center.Y, 0 );
                basicEffect.CurrentTechnique.Passes[0].Apply( );
                GraphicsDevice.DrawUserPrimitives<VertexPositionColor>( PrimitiveType.TriangleList, vertex, 0, 1 );
            }
            base.Draw( gameTime );
        }
        void DrawPlayerAreaByColor( Color color ) {
            Rectangle bounds = new Rectangle( 0, 0, S, S );
            spriteBatch.Draw( white, bounds, color );                       // Big area
            bounds.Inflate( -BLOCK_SIZE, -BLOCK_SIZE );
            spriteBatch.Draw( white, bounds, BackColor );                   // Background inside big area
            bounds.Inflate( -BLOCK_GAP, -BLOCK_GAP );
            spriteBatch.Draw( white, bounds, Color.White );                 // White area inside big area
            for (int x = 0; x < 2; x++)
                for (int y = 0; y < 2; y++) {
                    var mw = bounds.Width - 2 * BLOCK_SIZE - 4 * BLOCK_GAP;
                    var mh = bounds.Height - 2 * BLOCK_SIZE - 4 * BLOCK_GAP;
                    mw /= 3;
                    mh /= 3;
                    var mb = new Rectangle( bounds.X + mw, bounds.Y + mh, BLOCK_TOTAL_SIZE, BLOCK_TOTAL_SIZE );
                    mb.X += x * ( mw + BLOCK_SIZE + 2 * BLOCK_GAP );
                    mb.Y += y * ( mh + BLOCK_SIZE + 2 * BLOCK_GAP );
                    spriteBatch.Draw( white, mb, BackColor );
                    mb.Inflate( -BLOCK_GAP, -BLOCK_GAP );
                    spriteBatch.Draw( white, mb, color );
                }
            bounds = new Rectangle( 0, S, S, 3 * BLOCK_TOTAL_SIZE + BLOCK_GAP );
            spriteBatch.Draw( white, bounds, BackColor );
            for (int x = 0; x < 6; x++)
                for (int y = 0; y < 3; y++) {
                    bounds = new Rectangle( x * BLOCK_TOTAL_SIZE, S + BLOCK_GAP + y * BLOCK_TOTAL_SIZE, BLOCK_SIZE, BLOCK_SIZE );
                    spriteBatch.Draw( white, bounds, ( x == 1 && y == 0 || x > 0 && y == 1 ) ? color : Color.White );
                }
        }
