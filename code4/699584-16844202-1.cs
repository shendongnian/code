                    //Called Every Hit
                    public void ShockerGeneratorPlayerOne()
                    {
                        Random rnd = new Random();
                        RanShocMatch = rnd.Next(10);
                        if (RanShocMatch == 1)
                        {
                        //Speed Boost!
                            VelocityX = (VelocityX - 1);
                            VelocityY = (VelocityY - 1);
                        }
                        else if (RanShocMatch == 2)
                        {
                            if (ObjectBCalled == false)
                            {
                                ShocObjectBRectangle = new Rectangle(362, 200, 10, 100);
                                ObjectBCalled = true;
                            }
                        }
                        else if (RanShocMatch == 3)
                        {
                            if (ObjectACalled == false)
                            {
                                ShocObjectARectangle = new Rectangle(80, 200, 100, 10);
                                ObjectACalled = true;
                            }
                        }
                    }
    
                    //Called Every Hit
                    public void ShockerGeneratorPlayerTwo()
                    {
                        Random rnd = new Random();
                        RanShocMatch = rnd.Next(5);
                        if (RanShocMatch == 1)
                        {
                        //Speed Boost!
                            VelocityX = (VelocityX + 3);
                            VelocityY = (VelocityY + 3);
                        }
                    }
    
                    //Called When Player One Loses
                    public void PlayerOneLoses()
                    {
                    // MediaPlayer.Play(LosingBeep);
                        VelocityX = -BasicVelocity;
                        VelocityY = BasicVelocity;
                        BallBox.X += -360;
                        if (HitCount > highScore)
                            highScore = HitCount;
                        HitCount = 0;
                    } 
