            if ((previousgamepadstate.IsButtonUp(Buttons.RightTrigger) && gamepadstate.IsButtonDown(Buttons.RightTrigger))
                || (previouskeyboardstate.IsKeyUp(Keys.F) && keystate.IsKeyDown(Keys.F)))
            {
                bullets[currentbullet].alive = true;
                
                if (currentbullet < maxbullets - 1)
                {
                    currentbullet++;
                    bulletsound.Play();
                }
                else
                {
                    currentbullet = 0;
                }
            }
            foreach (Bullets bullet in bullets)
            {
                bullet.update_bulets(gametime, Position, velocity, rotation, viewport, bulletsound);
            }
