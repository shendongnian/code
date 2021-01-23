       public static void ticking(bool tick)
       {
        if(tick)
        {
        timerpartAnimation.Interval = TimeSpan.FromMilliseconds(1);
        }
        else
        {
        timerpartAnimation.Interval = TimeSpan.FromMilliseconds(0);
        }
       }
