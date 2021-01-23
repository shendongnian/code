    if (map[x][y] == 0)
            {
                if (speedBonus)
                {
                    float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                    timer -= elapsed;
                    car.speed = 450;
                    if (timer <= 0)
                    {
                        speedBonus = false;
                        timer = TIMER;   //Reset Timer
                    }
                }
                else
                {
                    car.speed = 200;
                }
