    gfx_rect = new Rectangle((int)position.X, (int)position.Y, gfx.Width, gfx.Height);
    
    foreach (var item in meteor_pos)      
        {
            meteor_rect = new Rectangle((int)item.X, (int)item.Y, gfx_meteor.Width, gfx_meteor.Height);
        
            if (gfx_rect.Intersects(meteor_rect))
                {
                    position.X = 0;
                    position.Y = 0;
                }
        }
