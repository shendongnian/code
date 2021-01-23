        if (horizisSelected)
        {
           //spritePosition.X-= 0.5f;
           //spritePosition.Y-= 0.5f;
           spritePosition += direction;// * 20 * gameTime.ElapsedGameTime.Milliseconds;
        }
        if (rotateSelected)
        {               
            rotation += 0.1f;
           // missle.rotateSprite(); 
            direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            //spritePosition += direction * 20 * gameTime.ElapsedGameTime.Milliseconds;
        }
