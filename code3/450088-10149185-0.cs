    var dates = new List<DateTime>
            {
                new DateTime(2012, 1, 1),
                new DateTime(2012, 2, 1),
                new DateTime(2012, 5, 1),
                new DateTime(2012, 7, 1),
                new DateTime(2012, 11, 1),
                new DateTime(2012, 12, 31)
            };
    var z = dates.Zip(dates.Skip(1), (f, s) => Tuple.Create(f.Equals(dates[0]) ? f : f.AddDays(1), s));
