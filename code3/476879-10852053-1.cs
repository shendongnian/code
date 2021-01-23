    Dictionary<int, Player> players = new Dictionary<int, Player>();
           
    foreach (var player in players.Values)
    {
       spriteBatch.Draw(texture, playerRectangle , null, Color.White, player.Rotation,
       new Vector2(texture.Width / 2, texture.Height / 2), 1f,
       SpriteEffects.None, 1f);
    }
