    void CheckCollision(Rectangle character)
    {
        int size = 16;
        if (character.Right > this.Position.X &&
            character.Left < this.Position.X + size &&
            character.Bottom > this.Position.Y &&
            character.Top > this.Position.Y + size)
        {
            //Character is colliding with tile
        }
    }
