    public void DrawLine(SpriteBatch spriteBatch, Vector2 lineStart, Vector2 lineEnd)
    {
        Vector2 d = lineEnd - lineStart;
        float angle = (float)Math.Atan2(d.Y, d.X);
        float distance = d.Length() + 1;
        if (angle == MathHelper.Pi || angle == -MathHelper.PiOver2)
        {
            distance--;
        }
        spriteBatch.Draw(ScreenManager.BlankTexture, 
            new Vector2(lineStart.X + 0.5f, lineStart.Y + 0.5f), 
            null, nodes[i].Item2, angle, new Vector2(0f, 0.5f),
            new Vector2(distance, level.GridLineThickness), 
            SpriteEffects.None, 0);
    }
