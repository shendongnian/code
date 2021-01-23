    private long recalculateStateTimestamp;
    private const long oneSecond = 10000000;
    .....
    long newTime = DateTime.Now.Ticks;
    if (newTime - recalculateStateTimestamp < oneSecond)
    {
        return;
    }
    recalculateStateTimestamp = newTime;
