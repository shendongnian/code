    DateTime currentTime = DateTime.Now;
    if (currentTime.Ticks > startTime.Ticks && currentTime.Ticks < endTime.Ticks)
    {
        return false;
    }
    return true
