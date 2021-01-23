    public void bulletCollision(GameTime gameTime)
    {
        foreach (var x in bullets)
        {
            foreach (var y in enemies)
            {
                enemy_rect = new Rectangle((int)y.position.X, (int)y.position.Y, 10, 10);
                bullet_rect = new Rectangle((int)x.position.X, (int)x.position.Y, 10, 10);
                if (bullet_rect.Intersects(enemy_rect))
                {
                    y.bulletColliding = true;
                }
            }
        }
    }
