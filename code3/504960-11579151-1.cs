    TimeSpan ts = DateTime.Now - DateTime.Now.AddHours(-10);
    int hh = (int) ts.TotalHours;
    int mm = (int) ts.Minutes;
    int ss = (int) ts.Seconds;
    Console.WriteLine(string.Format("{0:00}:{1:00}:{2:00}",hh,mm,ss));
