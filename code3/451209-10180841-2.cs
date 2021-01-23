        public ActionResult Trainings()
        {
            //dummy data
            var trainings = new List<Training>();
            trainings.Add(new Training { TrainingDay = DateTime.Now });
            var week = new Dictionary<DayOfWeek, List<Training>>() 
            { 
                { DayOfWeek.Monday, new List<Training>() },
                { DayOfWeek.Tuesday, new List<Training>() },
                { DayOfWeek.Wednesday, new List<Training>() },
                { DayOfWeek.Thursday, new List<Training>() },
                { DayOfWeek.Friday, new List<Training>() },
                { DayOfWeek.Saturday, new List<Training>() },
                { DayOfWeek.Sunday, new List<Training>() },
            };
            for (int i = 0; i < trainings.Count; i++) 
            {
                switch (trainings[i].TrainingDay.DayOfWeek)
                {
                    case DayOfWeek.Friday:
                        week[DayOfWeek.Friday].Add(trainings[i]);
                        break;
                    case DayOfWeek.Monday:
                        week[DayOfWeek.Monday].Add(trainings[i]);
                        break;
                    case .....
                }
            }
            return View(week);
        }
