        //This will move our camera
        ScrollCamera(spriteBatch.GraphicsDevice.Viewport);
        //We now must get the center of the screen
        Vector2 Origin = new Vector2(spriteBatch.GraphicsDevice.Viewport.Width / 2.0f, spriteBatch.GraphicsDevice.Viewport.Height / 2.0f);
        
        //Now the matrix, It will hold the position, and Rotation/Zoom for advanced features
        Matrix cameraTransform = Matrix.CreateTranslation(new Vector3(-cameraPosition, 0.0f)) *
           Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
           Matrix.CreateRotationZ(rot) * //Add Rotation
           Matrix.CreateScale(zoom, zoom, 1) * //Add Zoom
           Matrix.CreateTranslation(new Vector3(Origin, 0.0f)); //Add Origin
       
          //Now we can start to draw with our camera, using the Matrix overload
        spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default,
                                 RasterizerState.CullCounterClockwise, null, cameraTransform);
     
        
        DrawTiles(spriteBatch); //Or whatever method you have for drawing tiles
        spriteBatch.End(); //End the camera spritebatch
        // After this you can make another spritebatch without a camera to draw UI and things that will not move
