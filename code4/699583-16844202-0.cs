     switch (CurrentGameState)
                {
                case GameState.MainMenu:
                    if (btnPlay.isClicked == true) CurrentGameState = GameState.Playing;
                    btnPlay.Update(mouse);
                    break;
                case GameState.Playing:
                    if (Keyboard.GetState().IsKeyDown(Keys.Down))
                    {
                        if (POPBox.Y >= 373)
                        {
                            POPBox.Y += 0;
                        }
                        else
                        {
                            POPBox.Y += PlayersSpeed;
                        }
                    }
    
                    if (Keyboard.GetState().IsKeyDown(Keys.Up))
                    {
                        if (POPBox.Y <= 0)
                        {
                            POPBox.Y += 0;
                        }
                        else
                        {
                            POPBox.Y += -PlayersSpeed;
                        }
                    }
                    // Ball Limets
                    if (BallBox.Y <= 0)
                        VelocityY *= -1;
                    if (BallBox.Y >= 463)
                        VelocityY *= -1;
                    if (BallBox.X <= 0)
                        VelocityX *= -1;
                    //Collision Detection (Runs this code if it hits the player one's paddle)
                    if (BallBox.Intersects(POPBox))
                    {
                        //Used to deflect in different directions for some veriety
                        if (PlayersSpeed > 0)
                            VelocityY += 3;
                        if (PlayersSpeed < 0)
                            VelocityY -= 3;
                        VelocityX *= -1;
                        HitCount++;
                        ShockerGeneratorPlayerOne();
                        //Stopping the no slope bug. If it wants to bounce perfectly straight,                it is slightly shifty to fix that error.
                        if (VelocityY == 0)
                            VelocityY = VelocityY += 3;
                        if (VelocityX == 0)
                            VelocityX = VelocityX += 3;
                        //speed control
                        if (VelocityX > 10)
                            VelocityX = 10;
                        if (VelocityY > 10)
                            VelocityY = 10;
                     }
                    // Runs this code if the ball hits player two's paddle
                    if (BallBox.Intersects(PTPBox))
                    {
                        VelocityX *= -1;
                        ShockerGeneratorPlayerTwo();
                        if (VelocityY == 0)
                            VelocityY = VelocityY += 3;
                        if (VelocityX == 0)
                            VelocityX = VelocityX += 3;
                    }
    
                    //Object a collision
                    if (BallBox.Intersects(ShocObjectARectangle))
                    {
                        VelocityY *= -1;
                    }
                    if (BallBox.Intersects(ShocObjectBRectangle))
                    {
                        VelocityX *= -1;
                    }
                    // If Player One Loses
                    if (BallBox.X >= 790)
                    {
                        PlayerOneLoses();
                    }
                    //Player Two's "AI" and limets
                    if (PTPBox.Y >= 173)
                        PTPBox.Y += 0;
                    else
                        PTPBox.Y = BallBox.Y;
    
                    if (PTPBox.Y <= 0)
                        PTPBox.Y += 0;
                    else
                        PTPBox.Y = (BallBox.Y -30);
                    //Object A movement code
                    ShocObjectARectangle.X += ObjectASpeed;
                    if (ShocObjectARectangle.X <= 80)
                        ObjectASpeed *= -1;
                    else if (ShocObjectARectangle.X >= 600)
                        ObjectASpeed *= -1;
                    //Object B movement code
                    ShocObjectBRectangle.Y += ObjectBSpeed;
                    if (ShocObjectBRectangle.Y <= 0)
                        ObjectBSpeed *= -1;
                    else if (ShocObjectBRectangle.Y >= 415)
                        ObjectBSpeed *= -1;
                    // Ball Velocity
                    BallBox.Y += -VelocityY;
                    BallBox.X += VelocityX;
                    PlayersSpeed = 10;
                    break;
                }
            base.Update(gameTime);
