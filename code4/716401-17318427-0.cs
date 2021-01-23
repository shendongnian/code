    for(int i=rocketPosition.Count; i > 0 ; i--)
    {
       rocketPosition[i] = new Vector2(rocketPosition[i].X, rocketPosition[i].Y - rocketSpeed);
       Vector2 smokePosition = rocketPosition[i];
       smokePosition.X += Rocket.Width / 2 + smokeTexture.Width / 2 + randomizer.Next(10) - 5;
       smokePosition.Y += Rocket.Height + randomizer.Next(10) - 5;
       smokeList.Add(new Particle(smokePosition, gameTime.TotalGameTime.Milliseconds));
       if (rocketPosition[i].Y < 0 - Rocket.Height)
       {
           rocketPosition.RemoveAt(i);
       }
    }
    for(int i = smokeList.Count; i  > 0 ; i--)
    {
       if (smokeList[i].Time < gameTime.TotalGameTime.Milliseconds - smokeDuration)
       {
           smokeList.RemoveAt(i);
       }
    }
