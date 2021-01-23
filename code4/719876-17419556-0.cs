    long start = DateTime.Now.Ticks;
    TimeSpan duration = TimeSpan.FromMilliseconds(1000);
    do
    {
      //
    }
    while (DateTime.Now.Ticks - start < duration);
