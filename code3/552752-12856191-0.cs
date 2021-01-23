    private static DateTime FromMS(long microSec)
    {
        long milliSec = (long)(microSec / 1000);
        DateTime startTime = new DateTime(1970, 1, 1);
        TimeSpan time = TimeSpan.FromMilliseconds(milliSec);
        return startTime.Add(time);
    }
