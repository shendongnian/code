        GraphicsDevice.Clear(Color.ForestGreen);
        backRect.Width = 800;
        backRect.Height = 480;
        // TODO: Add your drawing code here
        // Start drawing
        spriteBatch.Begin();
        spriteBatch.Draw(backgroundTexture, backRect, Color.White);
        // Draw the Player
        spriteBatch.Draw(playerTexture, playerRect, Color.White);
        for (int i = 0; i < goblins.Count; i++)
        {
            spriteBatch.Draw(goblins[i].Texture, goblins[i].Rect, Color.White);
        }
        // Stop drawing
        spriteBatch.End();
        base.Draw(gameTime);
    }
