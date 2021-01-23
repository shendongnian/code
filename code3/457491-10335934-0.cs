                List<DateTime> list = new List<DateTime>();
                list.Add(DateTime.Now.AddDays(-1));
                list.Add(DateTime.Now);
                list.Add(DateTime.Now.AddDays(1));
                TimeSpan ts = new TimeSpan();
                double result = 0;
    
                ts = DateTime.Now - list[list.Count - 1];
                result = ts.TotalSeconds;
