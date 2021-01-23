    var minutes = 30;
    var now = DateTime.Now;
    var ticksMin = TimeSpan.FromMinutes(minutes).Ticks;
    DateTime rounded = new DateTime(((now.Ticks + (ticksMin/2)) / ticksMin) * ticksMin);
    var diff=rounded-now;
    var minUntilNext = diff.TotalMinutes > 0 ? diff.TotalMinutes : minutes + diff.TotalMinutes;
