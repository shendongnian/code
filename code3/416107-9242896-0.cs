                if (isAI) {
                    Ball b = Game1.ball; //this is AI
                    if (b.Y > padMiddle)
                        moveDown();
                    else if ((b.Y + height) < padMiddle)
                        moveUp();
                }
                else
                {
                    GamePadState currentState = GamePad.GetState(PlayerIndex.One);
                    if (currentState.IsButtonDown(Buttons.LeftThumbstickUp)
                    {
                        moveUp();
                    }
                    else if (currentState.IsButtonDown(Buttons.LeftThumbstickDown)
                    {
                        moveDown();
                    }
                }
