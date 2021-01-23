    protected override void Update(GameTime gameTime)
    {
        //If it is not already playing and there is collision, start playing
        if (!IsPlaying && BallHitEffect)
            IsPlaying = true;
        //Increment the frameTimePlayed by the time (in milliseconds) since the last frame
        if (IsPlaying)
            frameTimePlayed += gameTime.ElapsedGameTime.TotalMilliseconds;
        //If playing and we have not exceeded the time limit
        if (IsPlaying && frameTimePlayed < animationTime)
        {
             // TODO: Add update logic here, such as animation.Update()
             // And increment your frames (Using division to figure out how many frames per second)
        }
        //If exceeded time, reset variables and stop playing
        else if (IsPlaying && frameTimePlayed >= animationTime)
        {
            frameTimePlayed = 0;
            IsPlaying = false;
            // TODO: Possibly custom animation.Stop(), depending on your animation class
        }
    }
