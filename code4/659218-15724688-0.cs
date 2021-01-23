    public void Update(GameTime gametime)
    {
        if (currentFrame >= 0)
        {
            timer += gametime.ElapsedGameTime.Milliseconds;
            if (timer >= msBetweenFrames)
            {
                timer = 0;
                currentFrame++;
                if (currentFramr >= numberOfFrames - 1)
                    currentFrame = -1;
                rect.X = CurrentFrame * width;
                rect.Y = 0;
            }
        }
    }
    public void Render(SpriteBatch sb, Vector2 position, Color color)
    {
        if (currentFrame >= 0)
            sb.Draw(aniTex, position, rect, color, 0, Vector2.Zero, 2.0f, SpriteEffects.None, 0);
    }
