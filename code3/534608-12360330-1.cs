        static void Main(string[] args)
        {
            var files = Directory.GetFiles(@"c:\temp");
            var dest = @"c:\temp2";
            var rnd = new Random();
            int maxDelay = 60; // one minute
            var schedule = files.Select(f => new {FilePath = f, Delay = rnd.Next(maxDelay)}).ToList();
            schedule.Sort( (a,b) => a.Delay-b.Delay );
            var startTime = DateTime.Now;
            foreach (var s in schedule)
            {
                int curDelay = (int) (DateTime.Now - startTime).TotalSeconds;
                if (s.Delay <= curDelay) File.Copy(s.FilePath, Path.Combine(dest, Path.GetFileName(s.FilePath)));
                else {
                    Thread.Sleep((s.Delay-curDelay)*1000);
                    File.Copy(s.FilePath, Path.Combine(dest, Path.GetFileName(s.FilePath)));
                }
            }
        }
