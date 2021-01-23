    private readonly ISubject<GameTime> _drawTimer = 
                                             new BehaviorSubject<GameTime>(new GameTime());
    // ... //
    public override Draw(GameTime gameTime)
    {
        _drawTimer.OnNext(gameTime);
    }
