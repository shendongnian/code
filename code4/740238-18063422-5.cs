            //Increase the timer by the number of milliseconds since update was last called
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            //Check the timer is more than the chosen interval
            if (timer > interval)
            {
                //Show the next frame
                currentFrame++;
                //Reset the timer
                timer = 0f;
            }
            //If we are on the last frame, reset back to the one before the first frame (because currentframe++ is called next so the next frame will be 1!)
            currentFrame = currentFrame % 2;
            sourceRect = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);
            origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);
