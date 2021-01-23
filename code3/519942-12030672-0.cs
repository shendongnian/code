    if (i == currentPlayer)
    {
         SpriteColor = Color.White;
         spriteDepth = 0f; // Front
    }
    else
    {
         SpriteColor = Color.Gray;
         spriteDepth = 0.1f; // Back
    }
    spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
    spriteBatch.Draw(players[i].Sprite, SquareCentre, null, SpriteColor, 0f, SpriteCentre,0.5f, SpriteEffects.None, spriteDepth);
    spriteBatch.End();
