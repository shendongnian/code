    public static string PrintTimeSpan(int secs)
    {
       TimeSpan t = TimeSpan.FromSeconds(secs);
       string answer;
       if (t.TotalMinutes < 1.0)
       {
         answer = String.Format("{0}s", t.Seconds);
       }
       else if (t.TotalHours < 1.0)
       {
         answer = String.Format("{0}m:{1:D2}s", t.Minutes, t.Seconds);
       }
       else // more than 1 hour
       {
         answer = String.Format("{0}h:{1:D2}m:{2:D2}s", (int)t.TotalHours, t.Minutes, t.Seconds);
       }
       
       return answer;
    }
