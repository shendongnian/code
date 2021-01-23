if (input.RollPowerup == true)
{
    //generate a random powerup
    PowerupType type = (PowerupType)random.Next(Enum.GetNames(typeof(PowerupType)).Length);
   switch (type)
    {
        case PowerupType.BigBalls:
            {
                powerup.Reset(type, 10.0f, 1.0f);
                break;
            }
         case PowerupType.ShrinkBalls:
            {
                powerup.Reset(type, 10.0f, 1.0f);
                break;
            }
        case PowerupType.BigPaddle:
            {
                powerup.Reset(type, 10.0f, 1.0f);
                break;
            }
        case PowerupType.ShrinkEnemy:
            {
                powerup.Reset(type, 10.0f, 1.0f);
                break;
            }
        case PowerupType.SpeedBall:
            {
                powerup.Reset(type, 10.0f, 20.0f);
               break;
            }
        case PowerupType.Heal:
            {
                powerup.Reset(type, 1.0f, 1.0f);
                break;
            }
        case PowerupType.Regen:
            {
                powerup.Reset(type, 20.0f, 1.0f);
                break;
            }
    }
    powerupInitialized = false;
}
else if (input.ActivatePowerup == true)
{
    powerup.Activate();
}
if (powerup.IsActive)
{
    powerup.Update((float)gameTime.ElapsedGameTime.TotalMilliseconds);
}
