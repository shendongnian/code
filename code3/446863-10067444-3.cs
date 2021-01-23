    public void Update(GameTime pGameTime)
    {
       private TimeSpan mKeyDuration = TimeSpan.FromSeconds(0);
       ...
       if key is pressed this frame
          mKeyDuration += pGameTime.ElapsedGameTime;
       else if key was pressed last frame
          mKeyDuration = TimeSpan.FromSeconds(0);
       ...
    }
