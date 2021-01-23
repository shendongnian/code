    public class MyStopwatch : Stopwatch
    {
        public void Start(long afterMiliseconds)
        {
            Timer t = new Timer() { Interval = 1 };
            int i = 0;
            t.Tick += (s, e) =>
            {
                if (i++ == afterMiliseconds)
                {
                    Start();
                    t.Stop();
                }
            };
            t.Start();
        }
    }
    //use it
    var offsetTimeStamp = new System.TimeSpan(0,0,0).Add(TimeSpan.FromSeconds((double)jd.ActualTime));
    myStopwatch.Start((long)offsetTimeStamp.TotalMiliseconds);
