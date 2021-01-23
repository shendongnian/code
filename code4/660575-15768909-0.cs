           var dailySchedules = new List<StaffScheduler>() { 
                new StaffScheduler(1, "Morning"), 
                new StaffScheduler(2, "Lunch"), 
                new StaffScheduler(3, "Evening"), 
                new StaffScheduler(4, "Night")
            };
            List<DateRangeShift> shiftList = new List<DateRangeShift>();
            shiftList.Add(new DateRangeShift("Week 1", new DateTime(2013, 3, 4), new DateTime(2013, 3, 10)));
            shiftList.Add(new DateRangeShift("Week 2", new DateTime(2013, 3, 11), new DateTime(2013, 3, 17)));
            shiftList.Add(new DateRangeShift("Week 3", new DateTime(2013, 3, 18), new DateTime(2013, 3, 24)));
            shiftList.Add(new DateRangeShift("Week 4", new DateTime(2013, 3, 25), new DateTime(2013, 3, 31)));
            List<Staff> staffList = new List<Staff>();
            staffList.Add(new Staff(1, "Fred Smith"));
            staffList.Add(new Staff(2, "Charlie Brown"));
            staffList.Add(new Staff(3, "Samantha Green"));
            staffList.Add(new Staff(4, "Bash Malik"));
            staffList.Add(new Staff(5, "Bryan Griffiths"));
            staffList.Add(new Staff(6, "Akaash Patel"));
            staffList.Add(new Staff(7, "Kang-Hyun Kim"));
            staffList.Add(new Staff(8, "Pedro Morales"));
            var shiftSegmentSize = (int)Math.Floor((double)staffList.Count / (double)dailySchedules.Count);
            Dictionary<StaffScheduler, Staff[]> map = new Dictionary<StaffScheduler, Staff[]>();
            foreach (var schedule in dailySchedules)
            {
                map.Add(schedule, staffList.ToArray());
            }
            Random r = new Random();
            foreach (var shift in shiftList)
            {
                shift.Staff = new List<StaffMap>();
                foreach(var schedule in dailySchedules)
                {
                    int randomStaff_Index = r.Next(map[schedule].Length);
                    Staff randStaff = map[schedule][randomStaff_Index];
                    map[schedule] = map[schedule].Where(x => x != randStaff).ToArray();
                    shift.Staff.Add(new StaffMap(randStaff, schedule));
                }
            }
