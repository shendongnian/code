    DateTime expirationTime = orderTime.AddHours(4);
    TimeSpan timeRemaining = expirationTime - DateTime.UtcNow;
    if(timeRemaining<TimeSpan.Zero)
      Error("Expired");
    else
      Write("Remaining {0} hours {1} minutes",timeRemaining.Hours, timeRemaining.Minutes);
