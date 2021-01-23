            if (animCounter > 0)
            {
                animCounter -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                srcRect.X += srcRect.Width;
                animCounter = 0.5f;
            }
