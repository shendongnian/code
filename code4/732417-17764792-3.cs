            var schedulers = new Dictionary<string, TaskScheduler>();
            schedulers.Add("Meetings", new TaskScheduler(2));
            schedulers.Add("Jobs", new TaskScheduler(1));
            schedulers["Meetings"].Add("Meet Barack Obama", new TimeSpan(1, 0, 0, 15));
            schedulers["Jobs"].Add("Make a cheese sandwich :D", new TimeSpan(0, 2, 0, 15));
            if (schedulers.ContainsKey("Meetings"))
            {
                foreach (var job in schedulers["Meetings"])
                {
                    Console.WriteLine(job);
                }
            }
