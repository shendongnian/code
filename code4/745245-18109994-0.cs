    class Foo
    {
        int x;
        void Update(GameTime gameTime)
        {
            x++;
        }
        void Draw()
        {
            spriteBatch.Draw(texture, new Vector2(263 + x, 554), sourceRect,Color.White, 0f, origin, 1.0f, SpriteEffects.None, 0);
        }
    }
