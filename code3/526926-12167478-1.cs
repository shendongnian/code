       private void ScrollCamera(Viewport viewport)
            {
                //Add to the camera positon, So we can see the origin
                cameraPosition.X = cameraPosition.X + (viewport.Width / 2);
                cameraPosition.Y = cameraPosition.Y + (viewport.Height / 2);
                
                //Smoothly move the camera towards the player
                cameraPosition.X = MathHelper.Lerp(cameraPosition.X , Player.Position.X, 0.1f);
                cameraPosition.Y = MathHelper.Lerp(cameraPosition.Y, Player.Position.Y, 0.1f);
                //Undo the origin because it will be calculated with the Matrix (I know this isnt the best way but its what I had real quick)
                cameraPosition.X = cameraPosition.X -( viewport.Width / 2);
                cameraPosition.Y = cameraPosition.Y - (viewport.Height / 2);
             
                //Shake the camera, Use the mouse to scroll or anything like that, add it here (Ex, Earthquakes)
                //Round it, So it dosent try to draw in between 2 pixels
                cameraPosition.Y= (float)Math.Round(cameraPosition.Y);
                cameraPosition.X = (float)Math.Round(cameraPosition.X);
                
                //Clamp it off, So it stops scrolling near the edges
                cameraPosition.X = MathHelper.Clamp(cameraPosition.X, 1f, Width * Tile.Width);
                cameraPosition.Y = MathHelper.Clamp(cameraPosition.Y, 1f, Height * Tile.Height);
    
            }
