                Rectangle ballRect = new Rectangle((int)ballposition.X, (int)ballposition.Y, ballsprite.Width, ballsprite.Height);
    
                Rectangle handRect = new Rectangle((int)paddlePosition.X, (int)paddlePosition.Y, paddleSprite.Width, paddleSprite.Height/2);
    
                if (ballRect.Intersects(handRect))
                {
                    // Increase ball speed
                    ballSpeed.Y += 50;
    
                    if (ballSpeed.X < 0)
                        ballSpeed.X -= 50;
    
                    else
                        ballSpeed.X += 50;
    
                    // Send ball back up the screen
    
                    ballSpeed.Y *= -1;
                }
