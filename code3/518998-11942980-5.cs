    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(@"D:\Films");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < 100000; i++)
            {
                List<string> yesterdaysList = directory.GetFiles().Where(x =>
                    x.CreationTime.Date == DateTime.Today.AddDays(-1))
                    .Select(x => x.Name)
                    .ToList();
            }
            timer.Stop();
            TimeSpan elapsedtime = timer.Elapsed;
            Console.WriteLine(string.Format("{0:00}:{1:00}:{2:00}",
                elapsedtime.Minutes, elapsedtime.Seconds,
                elapsedtime.Milliseconds / 10));
            timer.Restart();
            // initialize this variable only one time
            DateTime yesterday = DateTime.Today.AddDays(-1);
            for (int i = 0; i < 100000; i++)
            {
                List<string> yesterdaysList = new List<string>();
                foreach (FileInfo flInfo in directory.GetFiles())
                {
                    // use directly flInfo.CreationTime and flInfo.Name 
                    // without create another variable 
                    if (flInfo.CreationTime.Date == yesterday.Date)
                    {
                        yesterdaysList.Add(flInfo.Name.Substring(3, 4));
                    }
                }
            }
            timer.Stop();
            elapsedtime = timer.Elapsed;
            Console.WriteLine(string.Format("{0:00}:{1:00}:{2:00}",
                elapsedtime.Minutes, elapsedtime.Seconds,
                elapsedtime.Milliseconds / 10));
            timer.Restart();
            for (int i = 0; i < 100000; i++)
            {
                List<string> list = new List<string>();
                foreach (FileInfo flInfo in directory.GetFiles())
                {
                    DateTime _yesterday = DateTime.Today.AddDays(-1);
                    String name = flInfo.Name.Substring(3, 4);
                    DateTime creationTime = flInfo.CreationTime;
                    if (creationTime.Date == _yesterday.Date)
                    {
                        list.Add(name);
                    }
                }
            }
            elapsedtime = timer.Elapsed;
            Console.WriteLine(string.Format("{0:00}:{1:00}:{2:00}",
                elapsedtime.Minutes, elapsedtime.Seconds,
                elapsedtime.Milliseconds / 10));
        }
    }
