            IList<Day> days = new List<Day>();
            days.Add(new Day { Name = "Sunday", Hours = "8am - 9pm" });
            days.Add(new Day { Name = "Monday", Hours = "8am - 10pm" });
            days.Add(new Day { Name = "Tuesday", Hours = "8am - 10pm" });
            days.Add(new Day { Name = "Wednesday", Hours = "8am - 10pm" });
            days.Add(new Day { Name = "Thursday", Hours = "9am - 10pm" });
            days.Add(new Day { Name = "Friday", Hours = "9am - 11pm" });
            days.Add(new Day { Name = "Saturday", Hours = "8am - 11pm" });
            var grouped = days.GroupBy(d => d.Hours).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var group in grouped)
            {
                sb.AppendFormat("{0}: {1}\n", group.Key, group.Select(g => g.Name).Aggregate((list, nextday) => list + ", " + nextday));
            }
            var table = sb.ToString();
