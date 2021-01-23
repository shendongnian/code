    long ALL_Ticks = DateTime.Now.Ticks; 
    // that's the ticks (from DateTime.MinValue) until 'now' (this very moment)
    long ticks = new DateTime(2012, 1, 31).ToLocalTime().Ticks;
    // that's the ticks until the beginning of today
    long yearmonthticks = new DateTime(2012, 1, 1).ToLocalTime().Ticks;
    // that's the ticks until the beginning of the month
    // etc..., the rest is simple subtractions
