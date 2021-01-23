    List<allItems> allStats = getAllStats(userId);
    List<Months> stats = new List<Months>();
    var asItems =
        from item in allStats
        group item by new { month = item.MonthNumber } into Month
        select new Months()
        {
            MonthNumber = Month.Key.month,
            Weeks = Month.Select(week => //Don't cast here, put a ToList() at the end.
                from weeks in allStats
                group weeks by new { week = weeks.WeekNumber } into Week
                select new Weeks()
                {
                    WeekNumber = week.WeekNumber,
                    Days = Month.Select(days =>
                        new Days()
                        {
                            PunchedInLate = days.PunchedInLate,
                            PunchedOutLate = days.PunchedOutLate,
                            DayOfWeek = days.DayOfWeek,
                            PunchInDate = days.PunchInDate,
                            PunchOutDate = days.PunchOutDate
                        }).ToList()
                }).ToList(); //*** ToList() added here ***
        };
    List<Months> stat = asItems.ToList();
