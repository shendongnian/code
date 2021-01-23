    RotationAngle += .5f;
    float circle = MathHelper.Pi * 2;
    RotationAngle = RotationAngle % circle;
    Vector2 origin = new Vector2(texture.Width / 2, texure.Height / 2);
    spriteBatch.Draw(texture, position, null, Color.White, RotationAngle, origin, 1.0f, SpriteEffects.None, 0f);
