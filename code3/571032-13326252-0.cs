    Stopwatch stopWatch = new Stopwatch();
     if (keystate.IsKeyDown(Keys.W))
             {
                 velocity.Y = 3 - (time elapsed since start of jump);
                 stopWatch.Start();
             }
     if (keystate.IsKeyUp(Keys.W))
    {
             stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
    
    }
