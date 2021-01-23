            public IEnumerable<DateTime> GetAllQuarters(DateTime current, DateTime past)
            {
                var curQ = (int)Math.Ceiling(current.Month / 3.0M);
                var lastQEndDate = new DateTime(current.Year, curQ * 3, 1).AddMonths(-2).AddDays(-1);
                do
                {
                    yield return lastQEndDate;
                    lastQEndDate = lastQEndDate.AddMonths(-3);
                } while (lastQEndDate > past);
            }
