    class Foo
    {
        int x;
        int maxX = 400;
        void Update(GameTime gameTime)
        {
            if (x++ >= maxX)
                x = 263;
        }
        void Draw()
        {
            spriteBatch.Draw(texture, new Vector2(263 + x, 554), sourceRect,Color.White, 0f, origin, 1.0f, SpriteEffects.None, 0);
        }
    }
