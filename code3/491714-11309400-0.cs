                        #region Turbo stuff
                    // If spaceBar is down and the turbo bar is not empty, activate turbo. If not, turbo remains off 
                    if (input.ActivateTurbo(ControllingPlayer))
                    {
                        if (disableCooldown > 0)
                        {
                            leftBat.isTurbo = true;
                            coolDown = powerEnableCooldown;
                            leftBat.moveSpeed = 30.0f;
                            disableCooldown -= gameTime.ElapsedGameTime.Milliseconds;
                        }
                        else
                        {
                            leftBat.DisableTurbo();
                        }
                    }
                        // If spacebar is not down, begin to refill the turbo bar
                    else
                    {
                        leftBat.DisableTurbo();
                        coolDown -= gameTime.ElapsedGameTime.Milliseconds;
                        // If the coolDown timer is not in effect, then the bat can use Turbo again
                        if (coolDown < 0)
                        {
                            disableCooldown = powerDisableCooldown;
                        }
                    }
                    // Makes sure that if Turbo is on, it is killd it after () seconds
                    if (leftBat.isTurbo)
                    {
                        disableCooldown -= gameTime.ElapsedGameTime.Milliseconds;
                    }
                    if (disableCooldown < 0)
                    {
                        leftBat.isTurbo = false;
                    }
                    #endregion 
